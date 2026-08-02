namespace aaasm.engine.num
{
    /// <summary>Utility for parsing numbers in binary notation</summary>
    public static class BinParse
    {
#pragma warning disable CS0675

        /// <summary>Attempts to parse the specified string to an 8-bit unsigned integer value</summary>
        /// <param name="s">String input</param>
        /// <param name="result">Parse result</param>
        /// <returns>Whether or not successful</returns>
        public static bool TryUInt8(string? s, out byte result)
        {
            const int binDigits = 4 * 2;
            if (s == null) goto invalid;
            if (s.Length > binDigits)
                goto invalid;
            result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c < '0' || c > '1') goto invalid;
                int digit = c - '0';
                //Update value
                result <<= 1;
                result |= (byte)digit;
            }
            return true;
        invalid:
            result = default;
            return false;
        }

        /// <summary>Attempts to parse the specified string to an 8-bit signed integer value</summary>
        /// <param name="s">String input</param>
        /// <param name="result">Parse result</param>
        /// <returns>Whether or not successful</returns>
        public static bool TryInt8(string? s, out sbyte result)
        {
            const int binDigits = 4 * 2;
            if (s == null) goto invalid;
            if (s.Length > binDigits)
                goto invalid;
            result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c < '0' || c > '1') goto invalid;
                int digit = c - '0';
                //Update value
                result <<= 1;
                result |= (sbyte)digit;
            }
            return true;
        invalid:
            result = default;
            return false;
        }

        /// <summary>Attempts to parse the specified string to a 16-bit unsigned integer value</summary>
        /// <param name="s">String input</param>
        /// <param name="result">Parse result</param>
        /// <returns>Whether or not successful</returns>
        public static bool TryUInt16(string? s, out ushort result)
        {
            const int binDigits = 4 * 4;
            if (s == null) goto invalid;
            if (s.Length > binDigits)
                goto invalid;
            result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c < '0' || c > '1') goto invalid;
                int digit = c - '0';
                //Update value
                result <<= 1;
                result |= (ushort)digit;
            }
            return true;
        invalid:
            result = default;
            return false;
        }

        /// <summary>Attempts to parse the specified string to a 16-bit signed integer value</summary>
        /// <param name="s">String input</param>
        /// <param name="result">Parse result</param>
        /// <returns>Whether or not successful</returns>
        public static bool TryInt16(string? s, out short result)
        {
            const int binDigits = 4 * 4;
            if (s == null) goto invalid;
            if (s.Length > binDigits)
                goto invalid;
            result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c < '0' || c > '1') goto invalid;
                int digit = c - '0';
                //Update value
                result <<= 1;
                result |= (short)digit;
            }
            return true;
        invalid:
            result = default;
            return false;
        }

        /// <summary>Attempts to parse the specified string to a 32-bit unsigned integer value</summary>
        /// <param name="s">String input</param>
        /// <param name="result">Parse result</param>
        /// <returns>Whether or not successful</returns>
        public static bool TryUInt32(string? s, out uint result)
        {
            const int binDigits = 4 * 8;
            if (s == null) goto invalid;
            if (s.Length > binDigits)
                goto invalid;
            result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c < '0' || c > '1') goto invalid;
                int digit = c - '0';
                //Update value
                result <<= 1;
                result |= (uint)digit;
            }
            return true;
        invalid:
            result = default;
            return false;
        }

        /// <summary>Attempts to parse the specified string to a 32-bit signed integer value</summary>
        /// <param name="s">String input</param>
        /// <param name="result">Parse result</param>
        /// <returns>Whether or not successful</returns>
        public static bool TryInt32(string? s, out int result)
        {
            const int binDigits = 4 * 8;
            if (s == null) goto invalid;
            if (s.Length > binDigits)
                goto invalid;
            result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c < '0' || c > '1') goto invalid;
                int digit = c - '0';
                //Update value
                result <<= 1;
                result |= (int)digit;
            }
            return true;
        invalid:
            result = default;
            return false;
        }

        /// <summary>Attempts to parse the specified string to a 64-bit unsigned integer value</summary>
        /// <param name="s">String input</param>
        /// <param name="result">Parse result</param>
        /// <returns>Whether or not successful</returns>
        public static bool TryUInt64(string? s, out ulong result)
        {
            const int binDigits = 4 * 16;
            if (s == null) goto invalid;
            if (s.Length > binDigits)
                goto invalid;
            result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c < '0' || c > '1') goto invalid;
                int digit = c - '0';
                //Update value
                result <<= 1;
                result |= (ulong)digit;
            }
            return true;
        invalid:
            result = default;
            return false;
        }

        /// <summary>Attempts to parse the specified string to a 64-bit signed integer value</summary>
        /// <param name="s">String input</param>
        /// <param name="result">Parse result</param>
        /// <returns>Whether or not successful</returns>
        public static bool TryInt64(string? s, out long result)
        {
            const int binDigits = 4 * 16;
            if (s == null) goto invalid;
            if (s.Length > binDigits)
                goto invalid;
            result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c < '0' || c > '1') goto invalid;
                int digit = c - '0';
                //Update value
                result <<= 1;
                result |= (long)digit;
            }
            return true;
        invalid:
            result = default;
            return false;
        }

#pragma warning restore CS0675
    }
}