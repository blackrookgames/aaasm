__all__ = ['CSStrUtil']

from io import\
    StringIO as _StringIO

from help import\
    StrUtil as _StrUtil

class CSStrUtil:
    """ Utility for handling C# string literals """

    @staticmethod
    def try_parse(s:str):
        """
        Attempts to parse a C# string literal\n
        Note: Interpolated strings are not currently supported

        :param s: String literal (including opening and closing quotation marks)
        :return: Parsed string (or None if parsing fails)
        """
        # What kind of literal is this?
        if len(s) <= 1: return None
        quote = '"'
        match s[0]:
            case '@':
                if len(s) <= 2: return None
                if not s.startswith('@"'): return None
                if not s.endswith('"'): return None
                input = s[2:-1]
            case '"':
                if len(s) <= 1: return None
                if len(s) > 5 and s.startswith('"""'):
                    if not s.endswith('"""'): return None
                    quote = '"""'
                    while True:
                        quote = quote + '"'
                        if len(s) < (len(quote) * 2): break
                        if not s.startswith(quote): break
                        if not s.endswith(quote): break
                    quote = quote[:-1]
                    input = s[len(quote):-len(quote)]
                else:
                    if not s.startswith('"'): return None
                    if not s.endswith('"'): return None
                    input = _StrUtil.parse_esc(s[1:-1])
            case _:
                return None
        # Make sure literal doesn't end prematurely
        premature = input.find(quote)
        if premature >= 0: return None
        # Success!!!
        return input