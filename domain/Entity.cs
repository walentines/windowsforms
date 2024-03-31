using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_project.domain
{
    public class Entity<TId>
    {
        protected TId Id { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Entity<TId>);
        }

        public TId GetId()
        {
            return this.Id;
        }

        public TId SetId(TId id)
        {
            return this.Id = id;
        }

        private bool Equals(Entity<TId> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(this.Id, other.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id);
        }

        public override string ToString()
        {
            return "Entity{" + "Id=" + this.Id + '}';
        }
    }
   }
