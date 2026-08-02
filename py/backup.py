import sys
sys.dont_write_bytecode = True

import os
import shutil
import pyhelp

from datetime import datetime
from io import StringIO
from pathlib import Path
from typing import Any, Generator
_file = Path(__file__).resolve()

EXT_CS = ".cs"
EXT_CS_PY = ".cs.py"

EXCLUDED_DIRS_PATH = [ "test" ]
EXCLUDED_DIRS_NAME = [ ".git", ".venv", "__pycache__", "bin", "obj" ]

class Excluded:
    def __init__(self, dir:Path):
        global EXCLUDED_DIRS_PATH, EXCLUDED_DIRS_NAME
        self.__dirs_path = [\
            dir.joinpath(_path).resolve()\
            for _path in EXCLUDED_DIRS_PATH]
        self.__dirs_name = [\
            _name\
            for _name in EXCLUDED_DIRS_NAME]
    def file_is_excluded(self, path:Path):
        if path.name.endswith(EXT_CS):
            pypath = path.parent.joinpath(path.name[:-len(EXT_CS)] + EXT_CS_PY)
            if pypath.is_file(): return True
        return False
    def dir_is_excluded(self, path:Path):
        for _path in self.__dirs_path:
            if path == _path: return True
        for _name in self.__dirs_name:
            if path.name == _name: return True
        return False

def dt2name(dt:datetime):
    with StringIO() as w:
        w.write(f"{dt.year:04d}")
        w.write(f"{dt.month:02d}")
        w.write(f"{dt.day:02d}")
        w.write(f"{dt.hour:02d}")
        w.write(f"{dt.minute:02d}")
        w.write(f"{dt.second:02d}")
        w.write(f"{dt.microsecond:06d}")
        return w.getvalue()
    
def try_rmdir(dir:Path):
    try:
        shutil.rmtree(dir)
    except Exception as e:
        print(e, file = sys.stderr)
        return False
    return True
    
def try_mkdir(dir:Path):
    try:
        dir.mkdir(parents = True, exist_ok = True)
    except Exception as e:
        print(e, file = sys.stderr)
        return False
    return True

def try_copy(src:Path, dest:Path):
    try:
        shutil.copy(src, dest)
    except Exception as e:
        print(e, file = sys.stderr)
        return False
    return True

def archive(in_dir:Path, out_file:Path):
    if '.' in out_file.name:
        index = out_file.name.rfind('.')
        base_name = out_file.parent.joinpath(out_file.name[:index])
        format = out_file.name[(index + 1):]
    else:
        base_name = out_file
        format = 'zip'
    try:
        save = shutil.make_archive(str(base_name), format, root_dir = in_dir)
    except Exception as e:
        print(e, file = sys.stderr)
        return None
    return Path(save)

def loop(src_dir:Path, dest_dir:Path, excluded:Excluded):
    files:list[tuple[Path, Path]] = []
    def _loop(src_dir:Path, dest_dir:Path):
        nonlocal excluded
        nonlocal files
        dirs:list[tuple[Path, Path]] = []
        for src_path in src_dir.iterdir():
            dest_path = dest_dir.joinpath(src_path.name)
            # Directory?
            if src_path.is_dir():
                # Add directory (if included)
                if not excluded.dir_is_excluded(src_path):
                    dirs.append((src_path, dest_path))
            # File?
            else:
                # Yield file (if included)
                if not excluded.file_is_excluded(src_path):
                    files.append((src_path, dest_path))
        for _src_dir, _dest_dir in dirs:
            _loop(_src_dir, _dest_dir)
    _loop(src_dir, dest_dir)
    return files

def main():
    code_dir = pyhelp.get_code_dir()
    bckp_dir = code_dir.joinpath("test").joinpath("bckps")
    bckp_file = bckp_dir.joinpath(dt2name(datetime.now()) + ".zip")
    temp_dir = bckp_dir.joinpath(".temp")
    # Initialize
    print("Initializing")
    if temp_dir.is_dir():
        if not try_rmdir(temp_dir):
            return 1
    # Find files
    files = loop(code_dir, temp_dir, Excluded(code_dir))
    print(f"{len(files)} file(s):")
    # Copy to temp
    created_dirs:set[Path] = set()
    def create_dir(dir:Path):
        nonlocal created_dirs
        # Has this already been created?
        if dir in created_dirs:
            return True
        # No! Does the parent need to be created?
        if dir != code_dir:
            if not create_dir(dir.parent):
                return False
        # Create directory
        if not try_mkdir(dir):
            return False
        created_dirs.add(dir)
        # Success!!!
        return True
    for i in range(len(files)):
        src_path, dest_path = files[i]
        print(f"{(i + 1)}/{len(files)}  {src_path}")
        # Create parent directory
        if not create_dir(dest_path.parent):
            return 1
        # Copy
        if not try_copy(src_path, dest_path):
            return 1
    # Create archive
    print("Creating archive")
    archive_path = archive(temp_dir, bckp_file)
    if archive_path is None:
        return 1
    # Finish up
    print("Finishing up")
    try_rmdir(temp_dir)
    # Success
    print(f"Saved to \"{archive_path}\"")
    return 0

if __name__ == '__main__':
    sys.exit(main())