namespace Challenges;

public class AddressBus
{
    private readonly byte[] _rom = new byte[0x80];
    private readonly byte[] _ram = new byte[0x40];
    private readonly byte[] _oam = new byte[0x20];
    
    private readonly SpecialRegisters _specialRegisters = new();
    
    private const byte Unused = 0;

    public AddressBus()
    {
        var romData = "Default data in ROM; It's just a sentence that contains exactly 0x80 (128 decimal) characters including spaces and punctuation.."u8;
        romData.CopyTo(_rom);

        var ramData = "Default data in RAM is just a sentence but with 64 characters..."u8;
        ramData.CopyTo(_ram);

        var oamData = "Default OAM is just a string too"u8;
        oamData.CopyTo(_oam);
    }

    public byte Read(byte address)
    {
        if (address <= 0x7F)
        {
            return _rom[address];
        }
        if (address is >= 0x80 and < 0xC0)
        {
            return _ram[address - 0x80];
        }
        if (address is >= 0xC0 and < 0xE0)
        {
            return _oam[address - 0xC0];
        }
        if (address is >= 0xE0 and < 0xF0)
        {
            return Unused;
        }
        if (address == 0xF0)
        {
            return _specialRegisters.Sound;
        }
        if (address == 0xF1)
        {
            return _specialRegisters.Divider;
        }
        if (address == 0xF2)
        {
            return _specialRegisters.Counter;
        }
        if (address == 0xF3)
        {
            return _specialRegisters.Modulo;
        }
        if (address == 0xF4)
        {
            return _specialRegisters.Control;
        }
        if (address == 0xF5)
        {
            return _specialRegisters.InterruptFlag;
        }
        if (address == 0xF6)
        {
            return _specialRegisters.WX;
        }
        if (address == 0xF7)
        {
            return _specialRegisters.WY;
        }
        if (address == 0xF8)
        {
            return _specialRegisters.SCX;
        }
        if (address == 0xF9)
        {
            return _specialRegisters.SCY;
        }
        if (address == 0xFA)
        {
            return _specialRegisters.LCDC;
        }
        if (address == 0xFB)
        {
            return _specialRegisters.STAT;
        }
        if (address == 0xFC)
        {
            return _specialRegisters.SerialTransfer;
        }
        if (address == 0xFD)
        {
            return _specialRegisters.SerialControl;
        }
        if (address == 0xFE)
        {
            return _specialRegisters.DirectMemoryAccess;
        }

        return _specialRegisters.InterruptEnabled;
    }
    
    public void Write(byte address, byte value)
    {
        if (address <= 0x7F)
        {
            // Can't write to Read Only Memory!
        }
        if (address is >= 0x80 and < 0xC0)
        {
            _ram[address - 0x80] = value;
        }
        if (address is >= 0xC0 and < 0xE0)
        {
            _oam[address - 0xC0] = value;
        }
        if (address is >= 0xE0 and < 0xF0)
        {
            // Unused
        }
        if (address == 0xF0)
        {
            _specialRegisters.Sound = value;
        }
        if (address == 0xF1)
        {
            _specialRegisters.Divider = value;
        }
        if (address == 0xF2)
        {
            _specialRegisters.Counter = value;
        }
        if (address == 0xF3)
        {
            _specialRegisters.Modulo = value;
        }
        if (address == 0xF4)
        {
            _specialRegisters.Control = value;
        }
        if (address == 0xF5)
        {
            _specialRegisters.InterruptFlag = value;
        }
        if (address == 0xF6)
        {
            _specialRegisters.WX = value;
        }
        if (address == 0xF7)
        {
            _specialRegisters.WY = value;
        }
        if (address == 0xF8)
        {
            _specialRegisters.SCX = value;
        }
        if (address == 0xF9)
        {
            _specialRegisters.SCY = value;
        }
        if (address == 0xFA)
        {
            _specialRegisters.LCDC = value;
        }
        if (address == 0xFB)
        {
            _specialRegisters.STAT = value;
        }
        if (address == 0xFC)
        {
            _specialRegisters.SerialTransfer = value;
        }
        if (address == 0xFD)
        {
            _specialRegisters.SerialControl = value;
        }
        if (address == 0xFE)
        {
            _specialRegisters.DirectMemoryAccess = value;
        }
        if (address == 0xFF)
        {
            _specialRegisters.InterruptEnabled = value;
        }
    }
}

public sealed class SpecialRegisters
{
    public byte Sound { get; set; } = 0xF0;
    public byte Divider { get; set; } = 0xF1;
    public byte Counter { get; set; } = 0xF2;
    public byte Modulo { get; set; } = 0xF3;
    public byte Control { get; set; } = 0xF4;
    public byte InterruptFlag { get; set; } = 0xF5;
    public byte WX { get; set; } = 0xF6;
    public byte WY { get; set; } = 0xF7;
    public byte SCX { get; set; } = 0xF8;
    public byte SCY { get; set; } = 0xF9;
    public byte LCDC { get; set; } = 0xFA;
    public byte STAT { get; set; } = 0xFB;
    public byte SerialTransfer { get; set; } = 0xFC;
    public byte SerialControl { get; set; } = 0xFD;
    public byte DirectMemoryAccess { get; set; } = 0xFE;
    public byte InterruptEnabled { get; set; } = 0xFF;
}