// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("qoKi5RGUpw73QeWvLrrW0alvGX4Cum53z/BWye45KrZhtIEZW4r1BE9FS6dZj17b6/BG6oxABEkGd4bVoV5wdyPGdC4UVlyLVLxoqrBh70Psoe/JAQbnJtjayvDNyIqaNyB6mHmU9Uqg+OR4EbDAHSGQG5sr34mDVkmhkKIhHO3NBkZI9xJfvVuq8Ur1R8Tn9cjDzO9DjUMyyMTExMDFxvrpkuPdhEuuG7H95ZS9BaabMd/TXrSVBb39KPAGWoDCL90gUHlTIUjRjyYvurN3c1iw6kEdRUKNsRcqMUfEysX1R8TPx0fExMV7F3zSzM7rjKWwrMaNIJWqY9Z9ECguy3Sas+iVwFIGLbXHRhmxR1tmVIGGwMG/NUzzMKdVAzQqAMfGxMXE");
        private static int[] order = new int[] { 11,13,7,9,7,9,9,11,11,12,10,13,13,13,14 };
        private static int key = 197;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
