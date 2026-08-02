import io as _io
import struct as _struct

from dataclasses import\
    dataclass as _dataclass
from datetime import\
    datetime as _datetime
from typing import\
    Generic as _Generic,\
    TypeVar as _TypeVar

T = _TypeVar('T')

#region helper

def _unsigned(numbits:int):
    return 0, (1 << numbits) - 1, numbits // 8

def _signed(numbits:int):
    hi = 1 << (numbits - 1)
    return -hi, hi - 1, 1 << numbits, numbits // 8

_U8_MIN, _U8_MAX, _ = _unsigned(8)
_I8_MIN, _I8_MAX, _I8_NUMVALS, _ = _signed(8)
_U16_MIN, _U16_MAX, _U16_SIZE = _unsigned(16)
_I16_MIN, _I16_MAX, _, _I16_SIZE = _signed(16)
_U32_MIN, _U32_MAX, _U32_SIZE = _unsigned(32)
_I32_MIN, _I32_MAX, _, _I32_SIZE = _signed(32)
_U64_MIN, _U64_MAX, _U64_SIZE = _unsigned(64)
_I64_MIN, _I64_MAX, _, _I64_SIZE = _signed(64)

_LAST_8 = 1 << 7
_LAST_16 = 1 << 15
_LAST_32 = 1 << 31
_LAST_64 = 1 << 63

#endregion

#region QuickRW

class QuickRWError(Exception): pass

#endregion

#region ReadResult

@_dataclass(frozen = True)
class ReadResult(_Generic[T]):
    readlen:int
    """ Number of bytes read """
    value:T
    """ Read value """

#endregion

#region u8

def pickle_u8(value:int):
    return bytes([ max(_U8_MIN, min(_U8_MAX, value)), ])

def unpickle_u8(data:bytes):
    if len(data) == 0: raise QuickRWError("Data cannot be empty.")
    return data[0]

def read_u8(data:bytes, start:int):
    try:
        return ReadResult(1, unpickle_u8(data[start:]))
    except:
        if start >= 0 and start <= len(data): raise
    raise IndexError("Starting index is out of range.")

#endregion

#region i8

def pickle_i8(value:int):
    value = max(_I8_MIN, min(_I8_MAX, value))
    return bytes([value if (value >= 0) else (value + _I8_NUMVALS), ])

def unpickle_i8(data:bytes):
    if len(data) == 0: raise QuickRWError("Data cannot be empty.")
    value = data[0]
    return value if (value < -_I8_MIN) else (value - _I8_NUMVALS)

def read_i8(data:bytes, start:int):
    try:
        return ReadResult(1, unpickle_i8(data[start:]))
    except:
        if start >= 0 and start <= len(data): raise
    raise IndexError("Starting index is out of range.")

#endregion

#region u16

def pickle_u16(value:int):
    return _struct.pack('<H', max(_U16_MIN, min(_U16_MAX, value)))

def unpickle_u16(data:bytes):
    if len(data) >= _U16_SIZE: return _struct.unpack('<H', data[:_U16_SIZE])[0]
    raise QuickRWError(f"Data length must be greater than or equal to {_U16_SIZE}.")

def read_u16(data:bytes, start:int):
    try:
        return ReadResult(2, unpickle_u16(data[start:]))
    except:
        if start >= 0 and start <= len(data): raise
    raise IndexError("Starting index is out of range.")

#endregion

#region i16

def pickle_i16(value:int):
    return _struct.pack('<h', max(_I16_MIN, min(_I16_MAX, value)))

def unpickle_i16(data:bytes):
    if len(data) >= _I16_SIZE: return _struct.unpack('<h', data[:_I16_SIZE])[0]
    raise QuickRWError(f"Data length must be greater than or equal to {_I16_SIZE}.")

def read_i16(data:bytes, start:int):
    try:
        return ReadResult(2, unpickle_i16(data[start:]))
    except:
        if start >= 0 and start <= len(data): raise
    raise IndexError("Starting index is out of range.")

#endregion

#region u32

def pickle_u32(value:int):
    return _struct.pack('<I', max(_U32_MIN, min(_U32_MAX, value)))

def unpickle_u32(data:bytes):
    if len(data) >= _U32_SIZE: return _struct.unpack('<I', data[:_U32_SIZE])[0]
    raise QuickRWError(f"Data length must be greater than or equal to {_U32_SIZE}.")

def read_u32(data:bytes, start:int):
    try:
        return ReadResult(4, unpickle_u32(data[start:]))
    except:
        if start >= 0 and start <= len(data): raise
    raise IndexError("Starting index is out of range.")

#endregion

#region i32

def pickle_i32(value:int):
    return _struct.pack('<i', max(_I32_MIN, min(_I32_MAX, value)))

def unpickle_i32(data:bytes):
    if len(data) >= _I32_SIZE: return _struct.unpack('<i', data[:_I32_SIZE])[0]
    raise QuickRWError(f"Data length must be greater than or equal to {_I32_SIZE}.")

def read_i32(data:bytes, start:int):
    try:
        return ReadResult(4, unpickle_i32(data[start:]))
    except:
        if start >= 0 and start <= len(data): raise
    raise IndexError("Starting index is out of range.")

#endregion

#region u64

def pickle_u64(value:int):
    return _struct.pack('<Q', max(_U64_MIN, min(_U64_MAX, value)))

def unpickle_u64(data:bytes):
    if len(data) >= _U64_SIZE: return _struct.unpack('<Q', data[:_U64_SIZE])[0]
    raise QuickRWError(f"Data length must be greater than or equal to {_U64_SIZE}.")

def read_u64(data:bytes, start:int):
    try:
        return ReadResult(8, unpickle_u64(data[start:]))
    except:
        if start >= 0 and start <= len(data): raise
    raise IndexError("Starting index is out of range.")

#endregion

#region i64

def pickle_i64(value:int):
    return _struct.pack('<q', max(_I64_MIN, min(_I64_MAX, value)))

def unpickle_i64(data:bytes):
    if len(data) >= _I64_SIZE: return _struct.unpack('<q', data[:_I64_SIZE])[0]
    raise QuickRWError(f"Data length must be greater than or equal to {_I64_SIZE}.")

def read_i64(data:bytes, start:int):
    try:
        return ReadResult(8, unpickle_i64(data[start:]))
    except:
        if start >= 0 and start <= len(data): raise
    raise IndexError("Starting index is out of range.")

#endregion

#region single

def pickle_single(value:float):
    return _struct.pack('<f', value)

def unpickle_single(data:bytes) -> float:
    if len(data) >= 4: return _struct.unpack('<f', data)[0]
    raise QuickRWError("Data length must be greater than or equal to 4.")

def read_single(data:bytes, start:int):
    try:
        return ReadResult(4, unpickle_single(data[start:]))
    except:
        if start >= 0 and start <= len(data): raise
    raise IndexError("Starting index is out of range.")

#endregion

#region double

def pickle_double(value:float):
    return _struct.pack('<d', value)

def unpickle_double(data:bytes) -> float:
    if len(data) >= 8: return _struct.unpack('<d', data)[0]
    raise QuickRWError("Data length must be greater than or equal to 8.")

def read_double(data:bytes, start:int):
    try:
        return ReadResult(8, unpickle_double(data[start:]))
    except:
        if start >= 0 and start <= len(data): raise
    raise IndexError("Starting index is out of range.")

#endregion

#region string

def read_string(data:bytes, start:int):
    pos = start
    # Determine length and size
    result = read_u32(data, pos)
    pos += result.readlen
    is16 = (result.value & _LAST_32) != 0
    length = result.value & (_LAST_32 - 1)
    # Get characters
    with _io.StringIO() as w:
        if is16:
            for _ in range(length):
                result = read_u16(data, pos)
                pos += result.readlen
                w.write(chr(result.value))
        else:
            for _ in range(length):
                result = read_u8(data, pos)
                pos += result.readlen
                w.write(chr(result.value))
        return ReadResult(pos - start, w.getvalue())

def pickle_string(value:str):
    # Determine length
    length = min(_LAST_32 - 1, len(value))
    # Determine size of each character
    is16:bool = False
    for i in range(length):
        is16 = (ord(value[i]) & 0xFF00) != 0
        if is16: break
    # Write
    with _io.BytesIO() as w:
        w.write(pickle_u32(length | (_LAST_32 if is16 else 0)))
        if is16:
            for i in range(length):
                w.write(pickle_u16(ord(value[i])))
        else:
            for i in range(length):
                w.write(pickle_u8(ord(value[i])))
        return w.getvalue()

def unpickle_string(data:bytes):
    return read_string(data, 0).value

#endregion

#region

def read_dt(data:bytes, start:int):
    pos = start
    year = read_u16(data, pos)
    pos += year.readlen
    month = read_u8(data, pos)
    pos += month.readlen
    day = read_u8(data, pos)
    pos += day.readlen
    hour = read_u8(data, pos)
    pos += hour.readlen
    minute = read_u8(data, pos)
    pos += minute.readlen
    second = read_u8(data, pos)
    pos += second.readlen
    microsecond = read_u32(data, pos)
    pos += microsecond.readlen
    return ReadResult(pos - start, _datetime(\
        year.value, month.value, day.value,\
        hour.value, minute.value, second.value, microsecond.value))

def pickle_dt(value:_datetime):
    with _io.BytesIO() as w:
        w.write(pickle_u16(value.year))
        w.write(pickle_u8(value.month))
        w.write(pickle_u8(value.day))
        w.write(pickle_u8(value.hour))
        w.write(pickle_u8(value.minute))
        w.write(pickle_u8(value.second))
        w.write(pickle_u32(value.microsecond))
        return w.getvalue()

def unpickle_dt(data:bytes):
    return read_dt(data, 0).value

#endregion