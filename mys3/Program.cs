using System;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using System.IO;
using System.Threading.Tasks;

namespace mys3
{
    class Program
    {
         private static IAmazonS3 s3Client;
        private const string filePath = "/home/ec2-user/environment/README.md";
        static void Main(string[] args)
        {
            s3Client = new AmazonS3Client(RegionEndpoint.USEast1);
            var bucketName = "mys3test1003";
            
            //Test git hub content
            //Create Bucket
            //s3Client.PutBucketAsync(bucketName).Wait();
           // Console.WriteLine("Created the bucket named '{0}'.", bucketName);
            
             // List available buckets
            // var response = s3Client.ListBucketsAsync().Result;
        
             // foreach (var bucket in response.Buckets)
             // {
//Console.WriteLine(bucket.BucketName);
             // }
           //   Delete bucket
              s3Client.DeleteBucketAsync(bucketName).Wait();
              Console.WriteLine("Deleted the bucket named '{0}'.", bucketName);
              
           // Upload a file
	       //UploadFileAsync(bucketName).Wait();

        }
         private static async Task UploadFileAsync(string bucketname)
        {
            var fileTransferUtility = new TransferUtility(s3Client);    
            await fileTransferUtility.UploadAsync(filePath, bucketname);
            Console.WriteLine("File upload completed");
        }
    }
}
