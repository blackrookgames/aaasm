__all__ = ['StrUtil']

from io import\
    StringIO as _StringIO

class StrUtil:
    """ Utility for handling strings """

    @staticmethod
    def compare(a:str, b:str):
        """
        Compares the two strings

        :param a:
            String A
        :param b:
            String B
        :return:
            - Less than zero: a precedes b
            - Equal to zero: a is equal to b
            - Greater than zero: a follows b
        """
        lencmp = len(a) - len(b)
        minlen = min(len(a), len(b))
        for i in range(minlen):
            c0 = ord(a[i])
            c1 = ord(b[i])
            if c0 != c1: return c0 - c1
        return lencmp
    
    @staticmethod
    def substr_at(s:str, sub:str, pos:int):
        """
        Checks if a substring exists at the specified position

        :param s: String that possibly contains the substring
        :param sub: Substring
        :param pos: Start position of substring
        :return: Whether or not the substring exists at the specified position
        :raises IndexError: Position is out of range
        """
        if pos < 0 or pos >= len(s):
            raise IndexError("Position is out of range.")
        if (pos + len(sub)) > len(s):
            return False
        for i in range(len(sub)):
            if s[pos + i] != sub[i]: return False
        return True
    
    @staticmethod
    def remove_ws(s:str):
        """
        Removes all whitespace from the string

        :param s: Input string
        :return: Resulting string
        """
        with _StringIO() as w:
            for c in s:
                if ord(c) <= 0x20: continue
                w.write(c)
            return w.getvalue()

    @staticmethod
    def parse_esc(s:str):
        with _StringIO() as w:
            pos = 0
            while pos < len(s):
                c = s[pos]
                pos += 1
                # Is this an escape sequence?
                if c != '\\':
                    w.write(c)
                    continue
                # Is this a simple escape sequence?
                if pos == len(s): break
                c = s[pos].lower()
                pos += 1
                escseq = None
                match c:
                    case 'n': escseq = '\n'
                    case 't': escseq = '\t'
                    case '\\': escseq = '\\'
                    case '\"': escseq = '\"'
                    case 'b': escseq = '\b'
                    case 'r': escseq = '\r'
                    case 'a': escseq = '\a'
                    case '0': escseq = '\0'
                    case '$': escseq = '$'
                    case '#': escseq = '#'
                if escseq is not None:
                    w.write(escseq)
                    continue
                # Is this is an ASCII or unicode sequence?
                if c == 'x': numdigits = 2
                elif c == 'u': numdigits = 4
                else: continue
                char = 0
                end = min(len(s), pos + numdigits)
                while pos < end:
                    c = ord(s[pos])
                    if c >= 0x30 and c <= 0x39:
                        digit = c - 0x30
                    elif c >= 0x41 and c <= 0x46:
                        digit = 10 + c - 0x41
                    elif c >= 0x61 and c <= 0x66:
                        digit = 10 + c - 0x61
                    else:
                        break
                    pos += 1
                    char <<= 4
                    char |= digit
                w.write(chr(char))
            return w.getvalue()