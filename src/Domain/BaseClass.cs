using System;

namespace Domain
{
    public abstract class BaseClass
    {
        #region Constructors and Destructors

        public BaseClass()
        {
            DataCadastro = DateTime.Now;
            Id = Guid.NewGuid();
        }

        #endregion

        #region Properties

        public Guid Id { get; protected set; }

        public DateTime DataCadastro { get; protected set; }

        #endregion

        #region Methods

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as BaseClass;

            if (compareTo == null) return false;
            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(this, null)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(BaseClass a, BaseClass b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;

            return a.Equals(b);
        }

        public static bool operator !=(BaseClass a, BaseClass b) => !(a == b);

        public override int GetHashCode() => HashCode.Combine(Id, DataCadastro);

        public override string ToString() => string.Format("{0} - Id: {1}", GetType().Name, Id);

        #endregion
    }
}
