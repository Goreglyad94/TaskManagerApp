using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace TaskManagerApp.Persistence.FileStorage
{
    public interface IFileStorageService
    {
        Task<ObjectId> UploadFileAsync(string fileName, Stream stream, CancellationToken cancellationToken = default);
        Task<IAsyncCursor<GridFSFileInfo>> GetFileAsync(string id, CancellationToken cancellationToken = default);
        Task DeleteFileAsync(string fileStorageId, CancellationToken cancellationToken = default);
    }

    public class FileStorageService : IFileStorageService
    {
        private readonly IGridFSBucket _gridFSBucket;

        public FileStorageService(IGridFSBucket gridFSBucket)
        {
            _gridFSBucket = gridFSBucket;
        }

        public async Task<IAsyncCursor<GridFSFileInfo>> GetFileAsync(string id, CancellationToken cancellationToken = default)
        {
            var filter = Builders<GridFSFileInfo>.Filter.Eq(x => x.IdAsBsonValue, BsonValue.Create(ObjectId.Parse(id)));

            return await _gridFSBucket.FindAsync(filter, cancellationToken: cancellationToken);
        }

        public async Task<ObjectId> UploadFileAsync(string fileName, Stream stream, CancellationToken cancellationToken = default)
        {
            return await _gridFSBucket.UploadFromStreamAsync(fileName, stream, cancellationToken: cancellationToken);
        }

        public async Task DeleteFileAsync(string fileStorageId, CancellationToken cancellationToken = default)
        {
            await _gridFSBucket.DeleteAsync(new ObjectId(fileStorageId), cancellationToken: cancellationToken);
        }
    }
}
