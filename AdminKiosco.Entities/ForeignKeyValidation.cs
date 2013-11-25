using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminKiosco.Entities
{
    public static class ForeignKeyValidation
    {
        public static bool Validate(object entity)
        {
            PaperEntities entities = new PaperEntities();

            if ((entity as Kiosco) != null)
            {
                Kiosco deleteItem = entity as Kiosco;
                var hayCliente = entities.Clientes.Where(e => e.KioscoId.Equals(deleteItem.Id)).FirstOrDefault();
                return hayCliente != null;
            }

            if ((entity as Precio) != null)
            {
                Precio deleteItem = entity as Precio;
                var hayPromocion = entities.Promocion.Where(e => e.PrecioId.Equals(deleteItem.Id)).FirstOrDefault();
                return hayPromocion != null;
            }

            if ((entity as Publicacion) != null)
            {
                Publicacion deleteItem = entity as Publicacion;
                var hayPromocion = entities.Promocion.Where(e => e.PublicacionId.Equals(deleteItem.Id)).FirstOrDefault();
                return hayPromocion != null;
            }

            if ((entity as Distribuidor) != null)
            {
                Distribuidor deleteItem = entity as Distribuidor;
                var haypublicacion = entities.Publicacion.Where(e => e.DistribuidorId.Equals(deleteItem.Id)).FirstOrDefault();
                return haypublicacion != null;
            }

            if ((entity as TipoPublicacion) != null)
            {
                TipoPublicacion deleteItem = entity as TipoPublicacion;
                var haypublicacion = entities.Publicacion.Where(e => e.TipoPublicacionId.Equals(deleteItem.Id)).FirstOrDefault();
                return haypublicacion != null;
            }

            if ((entity as Cliente) != null)
            {
                Cliente deleteItem = entity as Cliente;
                var haySuscripcion = entities.Subscripcion.Where(e => e.ClienteId.Equals(deleteItem.Id)).FirstOrDefault();
                return haySuscripcion != null;
            }

            if ((entity as Promocion) != null)
            {
                Promocion deleteItem = entity as Promocion;
                var haySuscripcion = entities.Subscripcion.Where(e => e.PromocionId.Equals(deleteItem.Id)).FirstOrDefault();
                return haySuscripcion != null;
            }


            //Default => try to delete item
            return true;
        }
    }
}
