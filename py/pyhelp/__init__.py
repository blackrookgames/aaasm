import shutil

from pathlib import Path
_filedir = Path(__file__).resolve().parent

from .quickrw import *

def change_ext(path:Path, ext:str):
    noext = path.name if ('.' not in path.name)\
        else path.name[:path.name.rfind(".")]
    return path.parent.joinpath(noext + ext)

def clear_pycache(dir:Path):
    prj_dirs = []
    def loop_thru(dir:Path):
        nonlocal prj_dirs
        for path in dir.iterdir():
            if not path.is_dir():
                continue
            if path.name == "__pycache__":
                shutil.rmtree(path)
            else:
                loop_thru(path)
        return
    loop_thru(dir)
    return prj_dirs

def get_code_dir():
    global _filedir
    codedir = _filedir
    while True:
        for path in codedir.iterdir():
            if path.is_file() and path.name.endswith(".code-workspace"):
                return codedir
        codedir = codedir.parent

def get_prj_dirs(dir:Path):
    prj_dirs = []
    def loop_thru(dir:Path):
        nonlocal prj_dirs
        subdirs = []
        for path in dir.iterdir():
            if path.is_file():
                if path.name.endswith(".csproj"):
                    prj_dirs.append(dir)
                    return
            else:
                subdirs.append(path)
        for subdir in subdirs:
            loop_thru(subdir)
        return
    loop_thru(dir)
    return prj_dirs

def get_save_dir(parent:Path, dontmake:bool = False):
    savedir = parent.joinpath(".save")
    if not dontmake:
        savedir.mkdir(parents = True, exist_ok = True)
    return savedir

