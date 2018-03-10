using System;

namespace MSK.Core.Module.ESAPI
{
    /// <summary> 
    /// The IRandomizer interface defines a set of methods for creating
    /// cryptographically random numbers and strings.
    /// </summary> 
    public interface IRandomizer
    {
        /// <summary> Returns a random bool.</summary>
        bool GetRandomBoolean();

        /// <summary> Generates a random GUID.</summary>
        Guid GetRandomGUID();

        /// <summary> 
        /// Gets a random string.
        /// </summary>
        /// <param name="length">
        /// The desired length.
        /// </param>
        /// <param name="characterSet">
        /// The desired character set.
        /// </param>
        /// <returns> The random string.
        /// </returns>
        string GetRandomString(int length, char[] characterSet);

        /// <summary> 
        /// Gets a random integer.        
        /// </summary>
        /// <param name="min">
        /// The minimum value.
        /// </param>
        /// <param name="max">
        /// The maximum value.        
        /// </param>
        /// <returns> 
        /// The random integer
        /// </returns>
        int GetRandomInteger(int min, int max);

        /// <summary>
        /// Returns an unguessable filename.
        /// </summary>
        /// <param name="extension">The extension for the filename</param>
        /// <returns>The unguessable filename</returns>
        string GetRandomFilename(string extension);

        /// <summary> 
        /// Gets a random double.
        /// 
        /// </summary>
        /// <param name="min">
        /// The minimum value.
        /// </param>
        /// <param name="max">
        /// The maximum value.        
        /// </param>
        /// <returns>
        /// The random double.
        /// </returns>
        double GetRandomDouble(double min, double max);

        /// <summary> Returns a random long.</summary>
        long GetRandomLong();

        /// <summary> Returns a random real.</summary>
        /// 
        /// <param name="min">
        /// The min value.
        /// </param>
        /// <param name="max">
        /// The max value.        
        /// </param>
        /// <returns>
        /// The random real.
        /// </returns>
        float GetRandomReal(float min, float max);
    }
}