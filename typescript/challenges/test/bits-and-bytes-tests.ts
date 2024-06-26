import {bitCount, byteCopy, byteSet, byteZero} from "../src/bits-and-bytes";

describe('BitsAndBytesTests', () => {
    test.each([
        [0x00, 0],
        [0x01, 1],
        [0x0c, 2],
        [0x04bc, 6],
        [0x01d97c, 11],
        [0xFFFFFFFF, 32]
    ])('bitCount returns the correct number of bits', (input, expected) => {
        const result = bitCount(input);
        expect(result).toBe(expected);
    });

    test.each([
        [new Uint8Array([0x01, 0x02, 0x03, 0x04]), 0, new Uint8Array([0x00, 0x00, 0x00, 0x00])],
        [new Uint8Array([0x01, 0x02, 0x03, 0x04]), 1, new Uint8Array([0x01, 0x00, 0x00, 0x00])],
        [new Uint8Array([0x01, 0x02, 0x03, 0x04]), 2, new Uint8Array([0x01, 0x02, 0x00, 0x00])],
        [new Uint8Array([0x01, 0x02, 0x03, 0x04]), 3, new Uint8Array([0x01, 0x02, 0x03, 0x00])],
        [new Uint8Array([0x01, 0x02, 0x03, 0x04]), 4, new Uint8Array([0x01, 0x02, 0x03, 0x04])],
        [new Uint8Array([0x01, 0x02, 0x03, 0x04]), 5, new Uint8Array([0x01, 0x02, 0x03, 0x04])]
    ])('byteCopy copies bytes correctly', (src, size, expected) => {
        const dst = new Uint8Array(src.length);
        byteCopy(src, dst, size);
        expect(dst).toEqual(expected);
    });

    test.each([
        [new Uint8Array([0x01, 0x02, 0x03, 0x04]), 0, new Uint8Array([0x01, 0x02, 0x03, 0x04])],
        [new Uint8Array([0x01, 0x02, 0x03, 0x04]), 1, new Uint8Array([0x00, 0x02, 0x03, 0x04])],
        [new Uint8Array([0x01, 0x02, 0x03, 0x04]), 2, new Uint8Array([0x00, 0x00, 0x03, 0x04])],
        [new Uint8Array([0x01, 0x02, 0x03, 0x04]), 3, new Uint8Array([0x00, 0x00, 0x00, 0x04])],
        [new Uint8Array([0x01, 0x02, 0x03, 0x04]), 4, new Uint8Array([0x00, 0x00, 0x00, 0x00])],
        [new Uint8Array([0x01, 0x02, 0x03, 0x04]), 5, new Uint8Array([0x00, 0x00, 0x00, 0x00])]
    ])('byteZero sets correct amount of bytes to zero', (a, size, expected) => {
        byteZero(a, size);
        expect(a).toEqual(expected);
    });

    test.each([
        [new Uint8Array([0x01, 0x02, 0x03, 0x04]), 0, new Uint8Array([0x01, 0x02, 0x03, 0x04])],
        [new Uint8Array([0x01, 0x02, 0x03, 0x04]), 1, new Uint8Array([0xaa, 0x02, 0x03, 0x04])],
        [new Uint8Array([0x01, 0x02, 0x03, 0x04]), 2, new Uint8Array([0xaa, 0xaa, 0x03, 0x04])],
        [new Uint8Array([0x01, 0x02, 0x03, 0x04]), 3, new Uint8Array([0xaa, 0xaa, 0xaa, 0x04])],
        [new Uint8Array([0x01, 0x02, 0x03, 0x04]), 4, new Uint8Array([0xaa, 0xaa, 0xaa, 0xaa])],
        [new Uint8Array([0x01, 0x02, 0x03, 0x04]), 5, new Uint8Array([0xaa, 0xaa, 0xaa, 0xaa])]
    ])('byteSet sets correct amount of bytes to value', (a, size, expected) => {
        const value = 0xaa;
        byteSet(a, value, size);
        expect(a).toEqual(expected);
    });
});