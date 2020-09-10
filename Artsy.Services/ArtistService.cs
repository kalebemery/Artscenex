using Artsy.Data;
using Artsy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artsy.Services
{
    public class ArtistService
    {
        private readonly Guid _userId;

        public ArtistService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateArtist(ArtistCreate model)
        {
            var entity =
                new Artist()
                {
                    Id = _userId,
                    FullName = model.FullName,
                    ArtistBio = model.ArtistBio,
                    ArtistType = model.ArtistType,
                    CreatedUTC = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Artists.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //need to get artist by artist type!!
        //should be no need to get all artists
        public IEnumerable<ArtistList> GetArtists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Artists
                        .Where(e => e.Id == _userId)
                        .Select(
                            e =>
                                new ArtistList
                                {
                                    ArtistId = e.ArtistId,
                                    FullName = e.FullName,
                                    ArtistType = e.ArtistType,
                                    Rating = e.Rating
                                }
                        );

                return query.ToArray();
            }
        }

        //public List<PieceList> GetArtistPieces()
        //{
        //    var _context = new ApplicationDbContext();
        //    var pieces = _context.Pieces.ToList();
        //    var pieceList = pieces.Select(a => new PieceList
        //    {
        //        PieceId = a.PieceId,
        //        Name = a.Name,
        //        Price = a.Price,
        //        PieceType = a.PieceType,
        //        ArtistId = a.ArtistId
        //    }).ToList();
        //    return pieceList;
            
            
            
            
        //}

        public ArtistDetail GetArtistById(int id)
        {


            //var pieceList = GetArtistPieces();
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Artists
                        .Single(e => e.ArtistId == id && e.Id == _userId);
                return
                    new ArtistDetail
                    {
                        ArtistId = entity.ArtistId,
                        FullName = entity.FullName,
                        ArtistBio = entity.ArtistBio,
                        ArtistType = entity.ArtistType,
                        Rating = entity.Rating,
                        CreatedUTC = entity.CreatedUTC,
                        ModifiedUTC = entity.ModifiedUTC,
                        Pieces = ctx.Pieces.Where(p => p.ArtistId == entity.ArtistId).ToList()
                    };
            }

        }
       // Pieces = ctx.Pieces.Where(p => p.ArtistId == entity.ArtistId).ToList()
        public ICollection<ArtistList> GetArtistByEnum(ArtistType? type)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Artists
                    .Where(e => e.ArtistType == type && e.Id == _userId)
                    .Select(
                        e =>
                            new ArtistList
                            {
                                ArtistId = e.ArtistId,
                                FullName = e.FullName,
                                ArtistType = e.ArtistType,
                                Rating = e.Rating
                            }
                        );
                return query.ToList();
            }
        }


        public bool UpdateArtist(ArtistEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Artists
                        .Single(e => e.ArtistId == model.ArtistId && e.Id == _userId);
                entity.FullName = model.FullName;
                entity.ArtistBio = model.ArtistBio;
                entity.ArtistType = model.ArtistType;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }



        public bool DeleteArtist(int artistId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Artists
                        .Single(e => e.ArtistId == artistId && e.Id == _userId);

                ctx.Artists.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }



    }

}
