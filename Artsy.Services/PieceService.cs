using Artsy.Data;
using Artsy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artsy.Services
{

    public class PieceService
    {
        private readonly Guid _userId;

        public PieceService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreatePiece(PieceCreate model)
        {
            var entity =
                new Piece()
                {

                    Name = model.Name,
                    Desc = model.Desc,
                    Price = model.Price,
                    Stock = model.Stock,
                    PieceType = model.PieceType,
                    ArtistId = model.ArtistId,
                    CreatedUTC = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Pieces.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PieceList> GetPieces()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Pieces
                        .Select(
                            e =>
                                new PieceList
                                {
                                    PieceId = e.PieceId,
                                    Name = e.Name,
                                    Price = e.Price,
                                    PieceType = e.PieceType,
                                    ArtistId = e.ArtistId
                                }
                        );

                return query.ToArray();
            }
        }

        public PieceDetail GetPieceById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Pieces
                        .SingleOrDefault(e => e.PieceId == id);
                return
                    new PieceDetail
                    {
                        PieceId = entity.PieceId,
                        Name = entity.Name,
                        Desc = entity.Desc,
                        Price = entity.Price,
                        Stock = entity.Stock,
                        PieceType = entity.PieceType,
                        ArtistId = entity.ArtistId,
                        CreatedUTC = entity.CreatedUTC,
                    };


            }
        }

        public ICollection<PieceList> GetPiecesByArtist(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Pieces
                    .Where(e => e.ArtistId == id)
                    .Select(
                        e =>
                            new PieceList
                            {
                                PieceId = e.ArtistId,
                                Name = e.Name,
                                Price = e.Price,
                                PieceType = e.PieceType,
                                ArtistId = e.ArtistId
                            }
                        );
                return query.ToList();

            }
        }
            



        public bool UpdatePiece(PieceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Pieces
                        .Single(e => e.PieceId == model.PieceId);
                                                                    
                entity.Name = model.Name;
                entity.Desc = model.Desc;
                entity.Price = model.Price;
                entity.Stock = model.Stock;
                entity.PieceType = model.PieceType;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePiece(int pieceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Pieces
                        .Single(e => e.PieceId == pieceId);
                                                    

                ctx.Pieces.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
