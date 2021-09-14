using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Model
{
    public class UploadDocument
    {
        public static string UploadDocumentOnAzure(byte[] fileData, string FileName, string MimeType, string BlobConnectionString, string BlobFolder)
        {
            try
            {
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(BlobConnectionString);
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(BlobFolder);  //TODO: Append Organization name instead of Org Id.
                //string fileName = this.GenerateFileName(strFileName);

                if (cloudBlobContainer.CreateIfNotExists())
                {
                    cloudBlobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
                }

                if (FileName != null && fileData != null)
                {
                    CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(FileName);
                    cloudBlockBlob.Properties.ContentType = MimeType;
                    cloudBlockBlob.UploadFromByteArray(fileData, 0, fileData.Length);
                    return cloudBlockBlob.Uri.AbsoluteUri;
                }
                return "";
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            #region Upload using base64


            #endregion
        }
    }
}
