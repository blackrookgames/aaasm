import sys
sys.dont_write_bytecode = True

import os
import subprocess
import pyhelp

from collections.abc import Iterable
from datetime import datetime
from pathlib import Path
from io import StringIO
_file = Path(__file__).resolve()

PYTHONPATH = "PYTHONPATH"

EXT_CS = ".cs"
EXT_CS_PY = ".cs.py"

def enough_args(args:list[str], min:int):
    if len(args) >= min: return True
    print(f"Not enough arguments", file = sys.stderr)
    return False

def try_str2path(s:str):
    try: return Path(s).resolve()
    except: pass
    print(f"Invalid path: {s}", file = sys.stderr)
    return None

def try_str2bool(s:str):
    try: return bool(s)
    except: pass
    print(f"Invalid boolean: {s}", file = sys.stderr)
    return None

def try_iterdir(dir:Path):
    try: return dir.iterdir()
    except: pass
    if not dir.is_dir():
        message = f"\"{dir}\" is not a directory."
    else:
        message = f"Could not iterate thru \"{dir}\"."
    print(message, file = sys.stderr)
    return None

def new_pythonpath(old_path:None|str, extra:Iterable[Path]):
    with StringIO() as w:
        for path in extra:
            w.write(str(path.resolve()))
            w.write(';' if (os.name == 'nt') else ':')
        if old_path is not None:
            w.write(old_path)
        return w.getvalue()

def save_get_path():
    dir = pyhelp.get_save_dir(_file.parent)
    return pyhelp.change_ext(dir.joinpath(_file.name), "")

def save_read(path:Path) -> tuple[datetime, set[Path]]:
    if not path.is_file():
        return datetime(1, 1, 1), set()
    with open(path, 'rb') as f:
        raw = f.read()
        pos = 0
        # Read date
        date = pyhelp.read_dt(raw, pos)
        pos += date.readlen
        # Read file paths
        files:set[Path] = set()
        while pos < len(raw):
            file = pyhelp.read_string(raw, pos)
            pos += file.readlen
            files.add(Path(file.value))
        # Success!!!
        return date.value, files
    return data

def save_write(path:Path, date:datetime, files:set[Path]):
    with open(path, 'wb') as f:
        # Write date
        f.write(pyhelp.pickle_dt(date))
        for file in files:
            f.write(pyhelp.pickle_string(str(file)))

def create(dir:Path):
    global PYTHONPATH
    old_paths = os.environ.get(PYTHONPATH)
    new_paths = new_pythonpath(old_paths, [ _file.parent.joinpath("modules") ])
    try:
        os.environ[PYTHONPATH] = new_paths
        savepath = save_get_path()
        old_date, old_files = save_read(savepath)
        new_date = datetime.now()
        new_files:set[Path] = set()
        def loop(dir:Path):
            global EXT_CS, EXT_CS_PY
            for path in dir.iterdir():
                # Subdirectory?
                if path.is_dir():
                    if not loop(path): return False
                # Source generator?
                elif path.name.endswith(EXT_CS_PY):
                    opath = Path(path.parent.joinpath(path.name[:-len(EXT_CS_PY)] + EXT_CS))
                    # Does the source need to be generated?
                    regen = not opath.is_file()
                    if not regen:
                        if path not in old_files:
                            regen = True
                        else:
                            regen = datetime.fromtimestamp(path.stat().st_mtime) > old_date
                    if regen:
                        print(opath)
                        with StringIO() as w:
                            result = subprocess.run(\
                                [sys.executable, path, "-B"],\
                                capture_output = True,\
                                text = True)
                            if result.returncode != 0:
                                return False
                            otext = result.stdout
                        with open(opath, 'w') as f:
                            f.write(f"// This was auto-generated from {path.name}\n")
                            f.write(otext)
                        if result.returncode != 0: return False
                    # Add file
                    new_files.add(path)
            # Success!!!
            return True
        for subdir in pyhelp.get_prj_dirs(dir):
            if not loop(subdir): return 1
        save_write(savepath, new_date, new_files)
    finally:
        if old_paths is None: os.environ.pop(PYTHONPATH)
        else: os.environ[PYTHONPATH] = old_paths
    return 0

def clean(dir:Path):
    def loop(dir:Path):
        global EXT_CS, EXT_CS_PY
        for path in dir.iterdir():
            # Subdirectory?
            if path.is_dir():
                loop(path)
            # Source generator?
            elif path.name.endswith(EXT_CS_PY):
                opath = Path(path.parent.joinpath(path.name[:-len(EXT_CS_PY)] + EXT_CS))
                if opath.is_file(): os.remove(opath)
    savepath = save_get_path()
    if savepath.is_file():
        os.remove(savepath)
    for subdir in pyhelp.get_prj_dirs(dir):
        loop(subdir)
    return 0

def clear(dir:Path, recursive:bool):
    def loop(dir:Path):
        global EXT_CS, EXT_CS_PY
        nonlocal recursive
        dir_iter = try_iterdir(dir)
        if dir_iter is None: return False
        for path in dir_iter:
            # Subdirectory?
            if path.is_dir():
                if recursive: loop(path)
            # Source generator?
            elif path.name.endswith(EXT_CS_PY):
                opath = Path(path.parent.joinpath(path.name[:-len(EXT_CS_PY)] + EXT_CS))
                if opath.is_file(): os.remove(opath)
        return True
    return 0 if loop(dir) else 1

def main():
    code_dir = pyhelp.get_code_dir()
    pyhelp.clear_pycache(code_dir)
    # Did user ask for help
    if "--help" in sys.argv or "-h" in sys.argv:
        assert len(sys.argv) >= 1
        print("create")
        print("Runs the source generator")
        print()
        print("clean")
        print("Removes all generated source code")
        print()
        print("clear <directory> [<recursive>]")
        print("Removes generated source code in the specified directory")
        print("<directory>    Directory")
        print("<recursive>    Whether or not to remove generated source code in subdirectories")
        print()
        return 0
    # What does user what?
    if len(sys.argv) <= 1:
        return create(code_dir)
    match sys.argv[1]:
        case 'create':
            return create(code_dir)
        case 'clean':
            return clean(code_dir)
        case 'clear':
            args = sys.argv[2:]
            if not enough_args(args, 1): return 1
            dir = try_str2path(args[0])
            if dir is None: return 1
            recursive = try_str2bool(args[1]) if (len(args) > 1) else False
            if recursive is None: return 1
            return clear(dir, recursive)
    print(f"Invalid command: {sys.argv[1]}", file = sys.stderr)
    return 1

if __name__ == '__main__':
    sys.exit(main())