using System.Text;

namespace Challenges.Tests;

public class AddressBusTests
{
    #region ReadTests
    
    [Fact]
    public void ReadAllBytesFromROM_AllBytesInTact()
    {
        var addressBus = new AddressBus();

        var rom = Enumerable
            .Range(0, 0x80)
            .Select(address => addressBus.Read((byte)address))
            .ToArray();
        
        Assert.Equal(
            "Default data in ROM; It's just a sentence that contains exactly 0x80 (128 decimal) characters including spaces and punctuation..",
            Encoding.UTF8.GetString(rom));
    }
    
    [Fact]
    public void ReadAllBytesFromRAM_AllBytesInTact()
    {
        var addressBus = new AddressBus();

        var ram = Enumerable
            .Range(0x80, 0x40)
            .Select(address => addressBus.Read((byte)address))
            .ToArray();
        
        Assert.Equal(
            "Default data in RAM is just a sentence but with 64 characters...",
            Encoding.UTF8.GetString(ram));
    }
    
    [Fact]
    public void ReadAllBytesFromOAM_AllBytesInTact()
    {
        var addressBus = new AddressBus();

        var oam = Enumerable
            .Range(0xC0, 0x20)
            .Select(address => addressBus.Read((byte)address))
            .ToArray();
        
        Assert.Equal(
            "Default OAM is just a string too",
            Encoding.UTF8.GetString(oam));
    }
    
    [Fact]
    public void ReadAllBytesFromUnusedMemory_AllBytesAreZero()
    {
        var addressBus = new AddressBus();

        var unusedMemory = Enumerable
            .Range(0xE0, 0x10)
            .Select(address => addressBus.Read((byte)address))
            .ToArray();
        
        Assert.All(unusedMemory, b => Assert.Equal(0, b));
    }
    
    [Theory]
    [InlineData(0xF0, 0xF0)]
    [InlineData(0xF1, 0xF1)]
    [InlineData(0xF2, 0xF2)]
    [InlineData(0xF3, 0xF3)]
    [InlineData(0xF4, 0xF4)]
    [InlineData(0xF5, 0xF5)]
    [InlineData(0xF6, 0xF6)]
    [InlineData(0xF7, 0xF7)]
    [InlineData(0xF8, 0xF8)]
    [InlineData(0xF9, 0xF9)]
    [InlineData(0xFA, 0xFA)]
    [InlineData(0xFB, 0xFB)]
    [InlineData(0xFC, 0xFC)]
    [InlineData(0xFD, 0xFD)]
    [InlineData(0xFE, 0xFE)]
    [InlineData(0xFF, 0xFF)]
    public void ReadAllBytesSpecialRegisters_AllRegistersHaveExpectedValue(byte registerAddress, byte expectedRegisterValue)
    {
        var addressBus = new AddressBus();

        var actualRegisterValue = addressBus.Read(registerAddress);
        
        Assert.Equal(expectedRegisterValue, actualRegisterValue);
    }

    #endregion

    #region WriteTests
    
    [Fact]
    public void WriteIncrementalValuesToROM_NoBytesChangedInROM()
    {
        var addressBus = new AddressBus();

        var actualRomData =
            Enumerable
                .Range(0, 0x80)
                .Select((address, i) =>
                {
                    addressBus.Write((byte)address, (byte)i); // Use index (i) as value
                    return addressBus.Read((byte)address);
                })
                .ToArray();
        
        Assert.Equal(
            "Default data in ROM; It's just a sentence that contains exactly 0x80 (128 decimal) characters including spaces and punctuation..",
            Encoding.UTF8.GetString(actualRomData));
    }
    
    [Fact]
    public void WriteIncrementalValuesToRAM_AllBytesAreWritten()
    {
        var addressBus = new AddressBus();

        var actualRamData = Enumerable
            .Range(0x80, 0x40)
            .Select((address, i) =>
            {
                addressBus.Write((byte)address, (byte)i);
                return addressBus.Read((byte)address);
            });
        var expectedRamData = Enumerable
            .Range(0, 0x40)
            .Select(value => (byte)value);
        
        Assert.True(actualRamData.SequenceEqual(expectedRamData));
    }
    
    [Fact]
    public void WriteIncrementalValuesToOAM_AllBytesAreWritten()
    {
        var addressBus = new AddressBus();
        
        var actualOamData = Enumerable
            .Range(0xC0, 0x20)
            .Select((address, i) =>
            {
                addressBus.Write((byte)address, (byte)i);
                return addressBus.Read((byte)address);
            });
        var expectedOamData = Enumerable
            .Range(0, 0x20)
            .Select(value => (byte)value);
        
        Assert.True(actualOamData.SequenceEqual(expectedOamData));
    }
    
    [Fact]
    public void WriteToUnusedMemory_AllBytesAreZero()
    {
        var addressBus = new AddressBus();

        var unusedMemory = Enumerable
            .Range(0xE0, 0x10)
            .Select((address, i) =>
            {
                addressBus.Write((byte)address, (byte)i);
                return addressBus.Read((byte)address);
            });
        
        Assert.All(unusedMemory, b => Assert.Equal(0, b));
    }
    
    [Theory]
    [InlineData(0xF0, 0x10)]
    [InlineData(0xF1, 0x11)]
    [InlineData(0xF2, 0x12)]
    [InlineData(0xF3, 0x13)]
    [InlineData(0xF4, 0x14)]
    [InlineData(0xF5, 0x15)]
    [InlineData(0xF6, 0x16)]
    [InlineData(0xF7, 0x17)]
    [InlineData(0xF8, 0x18)]
    [InlineData(0xF9, 0x19)]
    [InlineData(0xFA, 0x1A)]
    [InlineData(0xFB, 0x1B)]
    [InlineData(0xFC, 0x1C)]
    [InlineData(0xFD, 0x1D)]
    [InlineData(0xFE, 0x1E)]
    [InlineData(0xFF, 0x1F)]
    public void WriteValueToSpecialRegisters_SpecialRegisterIsUpdatedWithValue(byte registerAddress, byte expectedRegisterValue)
    {
        var addressBus = new AddressBus();
        
        addressBus.Write(registerAddress, expectedRegisterValue);
        var actualRegisterValue = addressBus.Read(registerAddress);
        
        Assert.Equal(expectedRegisterValue, actualRegisterValue);
    }
    
    #endregion
}