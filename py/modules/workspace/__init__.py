from pathlib import\
    Path as _Path
_filepath = _Path(__file__).resolve()

from ioutil import\
    PathUtil as _PathUtil

#region init

def _init():
    global _filepath, _root
    # root
    def _is_root(path:_Path): return path.joinpath("workspace.code-workspace").is_file()
    try: _ = _root # type: ignore
    except NameError: _root = _PathUtil.find_parent(_filepath, _is_root)
    if _root is None: raise Exception("Root directory could not be found.")

#endregion

#region properties

def root() -> _Path:
    """ Root directory of workspace """
    global _root
    return _root # type: ignore

#endregion

_init()