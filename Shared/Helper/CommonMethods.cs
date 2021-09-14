using Shared.Model;
using Shared.StaticConstants;
using Microsoft.AspNetCore.Http;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Shared.Helper
{
    public class CommonMethods
    {
        /// <summary>
        /// The EncryptStringToBytes
        /// </summary>
        /// <param name="plainText">The plainText<see cref="byte[]"/></param>
        /// <param name="key">The key<see cref="byte[]"/></param>
        /// <param name="iv">The iv<see cref="byte[]"/></param>
        /// <returns>The <see cref="byte[]"/></returns>


        private static Random random = new Random();

        public byte[] EncryptStringToBytes(string plainText, byte[] key, byte[] iv)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
            {
                throw new ArgumentNullException("plainText");
            }
            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            if (iv == null || iv.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            byte[] encrypted;
            // Create a RijndaelManaged object
            // with the specified key and IV.
            using (var rijAlg = new RijndaelManaged())
            {
                rijAlg.Mode = CipherMode.CBC;
                rijAlg.Padding = PaddingMode.PKCS7;
                rijAlg.FeedbackSize = 128;

                rijAlg.Key = key;
                rijAlg.IV = iv;

                // Create a decrytor to perform the stream transform.
                var encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }
        /// <summary>
        /// The DecryptStringFromBytes
        /// </summary>
        /// <param name="cipherText">The cipherText<see cref="byte[]"/></param>
        /// <param name="key">The key<see cref="byte[]"/></param>
        /// <param name="iv">The iv<see cref="byte[]"/></param>
        /// <returns>The <see cref="string"/></returns>
        public string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
            {
                throw new ArgumentNullException("cipherText");
            }
            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            if (iv == null || iv.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (var rijAlg = new RijndaelManaged())
            {
                //Settings
                rijAlg.Mode = CipherMode.CBC;
                rijAlg.Padding = PaddingMode.PKCS7;
                rijAlg.FeedbackSize = 128;

                rijAlg.Key = key;
                rijAlg.IV = iv;

                // Create a decrytor to perform the stream transform.
                var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption.
                using (var msDecrypt = new MemoryStream(cipherText))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }
        /// <summary>
        /// Convert to UTC DATETIme
        /// </summary>
        /// <param name="Date"></param>
        /// <param name="Timezone"></param>
        /// <returns></returns>

        public DateTime ConvertUtcTime(DateTime Date, string Timezone)
        {
            try
            {
                string str = string.Empty;
                if (Timezone == "IST")
                {
                    str = "India Standard Time";
                }
                else
                {
                    str = Timezone;
                }
                //InternalLogger.Error("Timezone from request :{0} And Date Before : {1}", str, Date.ToString());

                //TimeZoneInfo timeInfo = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneInfo.Local.IsDaylightSavingTime(Date) ?
                //                  TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName);
                Date = DateTime.SpecifyKind(Date, DateTimeKind.Unspecified);
                TimeZoneInfo timeInfo = TimeZoneInfo.FindSystemTimeZoneById(str);
                DateTime userTime = TimeZoneInfo.ConvertTimeToUtc(Date, timeInfo);
                //InternalLogger.Error(" Date After : "+ userTime.ToString());
                return userTime;
            }
            catch (Exception ex)
            {
                TimeZoneInfo timeInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                DateTime userTime = TimeZoneInfo.ConvertTimeToUtc(Date, timeInfo);
                return userTime;
            }

        }
        /// <summary>
        /// Convert from Utc Date
        /// </summary>
        /// <param name="Date"></param>
        /// <param name="Timezone"></param>
        /// <returns></returns>
        public DateTime ConvertFromUtcTime(DateTime Date, string Timezone)
        {
            try
            {
                string str = string.Empty;
                if (Timezone == "IST")
                {
                    str = "India Standard Time";
                }
                else
                {
                    str = Timezone;
                }
                //InternalLogger.Error("Timezone from request :{0} And Date Before : {1}", str, Date.ToString());
                //TimeZoneInfo timeInfo = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneInfo.Local.IsDaylightSavingTime(Date) ?
                //TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName);
                TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById(Timezone);
                bool isDaylight = tst.IsDaylightSavingTime(Date);
                //if (isDaylight)
                //{
                //    TimeZoneInfo timeInfo = TimeZoneInfo.FindSystemTimeZoneById(str);
                //    DateTime userTime = TimeZoneInfo.ConvertTimeFromUtc(Date, timeInfo);
                //    //InternalLogger.Error(" Date After : "+ userTime.ToString());
                //    return userTime.AddHours(-1);
                //}
                //else
                //{
                //    TimeZoneInfo timeInfo = TimeZoneInfo.FindSystemTimeZoneById(str);
                //    DateTime userTime = TimeZoneInfo.ConvertTimeFromUtc(Date, timeInfo);
                //    //InternalLogger.Error(" Date After : "+ userTime.ToString());
                //    return userTime;
                //}
                TimeZoneInfo timeInfo = TimeZoneInfo.FindSystemTimeZoneById(str);
                DateTime userTime = TimeZoneInfo.ConvertTimeFromUtc(Date, timeInfo);
                return userTime;
            }
            catch (Exception ex)
            {
                TimeZoneInfo timeInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"); //TO DO : need to fix this 
                DateTime userTime = TimeZoneInfo.ConvertTimeFromUtc(Date, timeInfo);
                return userTime;
            }

        }
        public TokenClaimsModal GetUserClaimsFromToken(HttpContext httpContext)
        {
            TokenClaimsModal tokenClaims = new TokenClaimsModal();

            try
            {
                //  HttpContext httpContext = HttpContext.Request.HttpContext;
                string authHeader = httpContext.Request.Headers["Authorization"];
                string timeZone = httpContext.Request.Headers["time-zone"];
                var handler = new JwtSecurityTokenHandler();
                var tokens = handler.ReadToken(authHeader.Replace("Bearer ", "")) as JwtSecurityToken;
                //var idClaim = ((ClaimsIdentity)httpContext.User.Identity).FindFirst(JwtClaimTypes.Subject) ?? ((ClaimsIdentity)httpContext.User.Identity).FindFirst(ClaimTypes.NameIdentifier);
                //var sub = idClaim != null ? idClaim.Value : string.Empty;
                //var NameClaim = ((ClaimsIdentity)httpContext.User.Identity).FindFirst(JwtClaimTypes.Name) ?? ((ClaimsIdentity)httpContext.User.Identity).FindFirst(ClaimTypes.Name);
                //var name = NameClaim != null ? NameClaim.Value : string.Empty;
                //var EmailClaim = ((ClaimsIdentity)httpContext.User.Identity).FindFirst(JwtClaimTypes.Email);
                //var email = EmailClaim != null ? EmailClaim.Value : string.Empty;
                var claimList = httpContext.User.Claims.ToList();
                var userID = string.Empty;
                var email = string.Empty;
                var roleId = string.Empty;
                if (claimList.Count > 0)
                {
                    tokenClaims.UserId = Convert.ToInt32(claimList.FirstOrDefault(claimRecord => claimRecord.Type == "sub").Value);
                    tokenClaims.EmailAddress = claimList.FirstOrDefault(claimRecord => claimRecord.Type == "EmailAddress").Value;
                    tokenClaims.RoleID = Convert.ToInt32(claimList.FirstOrDefault(claimRecord => claimRecord.Type == "RoleId").Value);
                    tokenClaims.staffId = Convert.ToInt32(claimList.FirstOrDefault(claimRecord => claimRecord.Type == "StaffId").Value.Length) > 0 ? Convert.ToInt32(claimList.FirstOrDefault(claimRecord => claimRecord.Type == "StaffId").Value) : 0;
                    tokenClaims.timeZone = timeZone != string.Empty && timeZone != null ? timeZone : "India Standard Time";
                }
                return tokenClaims;

            }
            catch (Exception ex)
            {

                return tokenClaims;
            }


        }
        public bool checkForMobileCall(HttpContext httpContext)
        {
            //  HttpContext httpContext = HttpContext.Request.HttpContext;
            string apiKey = httpContext.Request.Headers["x-api-key"];

            if (apiKey == SharedConstants.mobKey)
            {
                return true;
            }
            else
            {
                return false;
            }

            //var patientDetails = _service.GetPatientDetails(tokenS.Subject);

            //string email = tokenS.
            // return patientDetails;

        }
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public string DecryptRijndael(string value)
        {
            var keybytes = Encoding.UTF8.GetBytes(SharedConstants.keybytes);
            var iv = Encoding.UTF8.GetBytes(SharedConstants.iv);
            //   var key = Encoding.UTF8.GetBytes(encryptionKey); //must be 16 chars 
            var rijndael = new RijndaelManaged
            {
                BlockSize = 128,
                IV = keybytes,
                KeySize = 192,
                Key = keybytes
            };

            var buffer = Convert.FromBase64String(value);
            var transform = rijndael.CreateDecryptor();
            string decrypted;
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, transform, CryptoStreamMode.Write))
                {
                    cs.Write(buffer, 0, buffer.Length);
                    cs.FlushFinalBlock();
                    decrypted = Encoding.UTF8.GetString(ms.ToArray());
                    cs.Close();
                }
                ms.Close();
            }

            return decrypted;

        }

    }
}
