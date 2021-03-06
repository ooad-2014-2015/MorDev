#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EnterSpaceGuide
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
using System.IO;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Data.Linq.Mapping;
using Microsoft.Phone.Data.Linq;


public class DebugWriter : TextWriter
{
    private const int DefaultBufferSize = 256;
    private System.Text.StringBuilder _buffer;

    public DebugWriter()
    {
        BufferSize = 256;
        _buffer = new System.Text.StringBuilder(BufferSize);
    }

    public int BufferSize
    {
        get;
        private set;
    }

    public override System.Text.Encoding Encoding
    {
        get { return System.Text.Encoding.UTF8; }
    }

    #region StreamWriter Overrides
    public override void Write(char value)
    {
        _buffer.Append(value);
        if (_buffer.Length >= BufferSize)
            Flush();
    }

    public override void WriteLine(string value)
    {
        Flush();

        using(var reader = new StringReader(value))
        {
            string line; 
            while( null != (line = reader.ReadLine()))
                System.Diagnostics.Debug.WriteLine(line);
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            Flush();
    }

    public override void Flush()
    {
        if (_buffer.Length > 0)
        {
            System.Diagnostics.Debug.WriteLine(_buffer);
            _buffer.Clear();
        }
    }
    #endregion
}


	public partial class ESGLokalnaBazaContext : System.Data.Linq.DataContext
	{
		
		public bool CreateIfNotExists()
		{
			bool created = false;
			if (!this.DatabaseExists())
			{
				string[] names = this.GetType().Assembly.GetManifestResourceNames();
				string name = names.Where(n => n.EndsWith(FileName)).FirstOrDefault();
				if (name != null)
				{
					using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
					{
						if (resourceStream != null)
						{
							using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
							{
								using (IsolatedStorageFileStream fileStream = new IsolatedStorageFileStream(FileName, FileMode.Create, myIsolatedStorage))
								{
									using (BinaryWriter writer = new BinaryWriter(fileStream))
									{
										long length = resourceStream.Length;
										byte[] buffer = new byte[32];
										int readCount = 0;
										using (BinaryReader reader = new BinaryReader(resourceStream))
										{
											// read file in chunks in order to reduce memory consumption and increase performance
											while (readCount < length)
											{
												int actual = reader.Read(buffer, 0, buffer.Length);
												readCount += actual;
												writer.Write(buffer, 0, actual);
											}
										}
									}
								}
							}
							created = true;
						}
						else
						{
							this.CreateDatabase();
							created = true;
						}
					}
				}
				else
				{
					this.CreateDatabase();
					created = true;
				}
			}
			return created;
		}
		
		public bool LogDebug
		{
			set
			{
				if (value)
				{
					this.Log = new DebugWriter();
				}
			}
		}
		
		public static string ConnectionString = "Data Source=isostore:/ESGLokalnaBaza.sdf";

		public static string ConnectionStringReadOnly = "Data Source=appdata:/ESGLokalnaBaza.sdf;File Mode=Read Only;";

		public static string FileName = "ESGLokalnaBaza.sdf";

		public ESGLokalnaBazaContext(string connectionString) : base(connectionString)
		{
			OnCreated();
		}
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertAtrakcije(Atrakcije instance);
    partial void UpdateAtrakcije(Atrakcije instance);
    partial void DeleteAtrakcije(Atrakcije instance);
    partial void InsertKorisnici(Korisnici instance);
    partial void UpdateKorisnici(Korisnici instance);
    partial void DeleteKorisnici(Korisnici instance);
    partial void InsertProblemi(Problemi instance);
    partial void UpdateProblemi(Problemi instance);
    partial void DeleteProblemi(Problemi instance);
    partial void InsertPutovanja(Putovanja instance);
    partial void UpdatePutovanja(Putovanja instance);
    partial void DeletePutovanja(Putovanja instance);
    #endregion
		
		public System.Data.Linq.Table<Atrakcije> Atrakcije
		{
			get
			{
				return this.GetTable<Atrakcije>();
			}
		}
		
		public System.Data.Linq.Table<Korisnici> Korisnici
		{
			get
			{
				return this.GetTable<Korisnici>();
			}
		}
		
		public System.Data.Linq.Table<Problemi> Problemi
		{
			get
			{
				return this.GetTable<Problemi>();
			}
		}
		
		public System.Data.Linq.Table<Putovanja> Putovanja
		{
			get
			{
				return this.GetTable<Putovanja>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute()]
	public partial class Atrakcije : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Naziv;
		
		private System.Data.Linq.Binary _Slika;
		
		private string _Opis;
		
		private System.DateTime _Vrijeme;
		
		private int _Dan;
		
		private int _Id_putovanja;
		
		private EntityRef<Putovanja> _Putovanja;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNazivChanging(string value);
    partial void OnNazivChanged();
    partial void OnSlikaChanging(System.Data.Linq.Binary value);
    partial void OnSlikaChanged();
    partial void OnOpisChanging(string value);
    partial void OnOpisChanged();
    partial void OnVrijemeChanging(System.DateTime value);
    partial void OnVrijemeChanged();
    partial void OnDanChanging(int value);
    partial void OnDanChanged();
    partial void OnId_putovanjaChanging(int value);
    partial void OnId_putovanjaChanged();
    #endregion
		
		public Atrakcije()
		{
			this._Putovanja = default(EntityRef<Putovanja>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Naziv", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Naziv
		{
			get
			{
				return this._Naziv;
			}
			set
			{
				if ((this._Naziv != value))
				{
					this.OnNazivChanging(value);
					this.SendPropertyChanging();
					this._Naziv = value;
					this.SendPropertyChanged("Naziv");
					this.OnNazivChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Slika", DbType="Image NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Slika
		{
			get
			{
				return this._Slika;
			}
			set
			{
				if ((this._Slika != value))
				{
					this.OnSlikaChanging(value);
					this.SendPropertyChanging();
					this._Slika = value;
					this.SendPropertyChanged("Slika");
					this.OnSlikaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Opis", DbType="NVarChar(500) NOT NULL", CanBeNull=false)]
		public string Opis
		{
			get
			{
				return this._Opis;
			}
			set
			{
				if ((this._Opis != value))
				{
					this.OnOpisChanging(value);
					this.SendPropertyChanging();
					this._Opis = value;
					this.SendPropertyChanged("Opis");
					this.OnOpisChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Vrijeme", DbType="DateTime NOT NULL")]
		public System.DateTime Vrijeme
		{
			get
			{
				return this._Vrijeme;
			}
			set
			{
				if ((this._Vrijeme != value))
				{
					this.OnVrijemeChanging(value);
					this.SendPropertyChanging();
					this._Vrijeme = value;
					this.SendPropertyChanged("Vrijeme");
					this.OnVrijemeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Dan", DbType="Int NOT NULL")]
		public int Dan
		{
			get
			{
				return this._Dan;
			}
			set
			{
				if ((this._Dan != value))
				{
					this.OnDanChanging(value);
					this.SendPropertyChanging();
					this._Dan = value;
					this.SendPropertyChanged("Dan");
					this.OnDanChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_putovanja", DbType="Int NOT NULL")]
		public int Id_putovanja
		{
			get
			{
				return this._Id_putovanja;
			}
			set
			{
				if ((this._Id_putovanja != value))
				{
					if (this._Putovanja.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnId_putovanjaChanging(value);
					this.SendPropertyChanging();
					this._Id_putovanja = value;
					this.SendPropertyChanged("Id_putovanja");
					this.OnId_putovanjaChanged();
				}
			}
		}
		
		[global::System.Runtime.Serialization.IgnoreDataMember]
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="putovanja_fk", Storage="_Putovanja", ThisKey="Id_putovanja", OtherKey="Id", IsForeignKey=true)]
		public Putovanja Putovanja
		{
			get
			{
				return this._Putovanja.Entity;
			}
			set
			{
				Putovanja previousValue = this._Putovanja.Entity;
				if (((previousValue != value) 
							|| (this._Putovanja.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Putovanja.Entity = null;
						previousValue.Atrakcije.Remove(this);
					}
					this._Putovanja.Entity = value;
					if ((value != null))
					{
						value.Atrakcije.Add(this);
						this._Id_putovanja = value.Id;
					}
					else
					{
						this._Id_putovanja = default(int);
					}
					this.SendPropertyChanged("Putovanja");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute()]
	public partial class Korisnici : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Ime;
		
		private string _Prezime;
		
		private string _KorisnickoIme;
		
		private int _Tip;
		
		private string _Sifra;
		
		private EntitySet<Problemi> _Problemi;
		
		private EntitySet<Putovanja> _Putovanja;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnImeChanging(string value);
    partial void OnImeChanged();
    partial void OnPrezimeChanging(string value);
    partial void OnPrezimeChanged();
    partial void OnKorisnickoImeChanging(string value);
    partial void OnKorisnickoImeChanged();
    partial void OnTipChanging(int value);
    partial void OnTipChanged();
    partial void OnSifraChanging(string value);
    partial void OnSifraChanged();
    #endregion
		
		public Korisnici()
		{
			this._Problemi = new EntitySet<Problemi>(new Action<Problemi>(this.attach_Problemi), new Action<Problemi>(this.detach_Problemi));
			this._Putovanja = new EntitySet<Putovanja>(new Action<Putovanja>(this.attach_Putovanja), new Action<Putovanja>(this.detach_Putovanja));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ime", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Ime
		{
			get
			{
				return this._Ime;
			}
			set
			{
				if ((this._Ime != value))
				{
					this.OnImeChanging(value);
					this.SendPropertyChanging();
					this._Ime = value;
					this.SendPropertyChanged("Ime");
					this.OnImeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Prezime", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Prezime
		{
			get
			{
				return this._Prezime;
			}
			set
			{
				if ((this._Prezime != value))
				{
					this.OnPrezimeChanging(value);
					this.SendPropertyChanging();
					this._Prezime = value;
					this.SendPropertyChanged("Prezime");
					this.OnPrezimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KorisnickoIme", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string KorisnickoIme
		{
			get
			{
				return this._KorisnickoIme;
			}
			set
			{
				if ((this._KorisnickoIme != value))
				{
					this.OnKorisnickoImeChanging(value);
					this.SendPropertyChanging();
					this._KorisnickoIme = value;
					this.SendPropertyChanged("KorisnickoIme");
					this.OnKorisnickoImeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Tip", DbType="Int NOT NULL")]
		public int Tip
		{
			get
			{
				return this._Tip;
			}
			set
			{
				if ((this._Tip != value))
				{
					this.OnTipChanging(value);
					this.SendPropertyChanging();
					this._Tip = value;
					this.SendPropertyChanged("Tip");
					this.OnTipChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sifra", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Sifra
		{
			get
			{
				return this._Sifra;
			}
			set
			{
				if ((this._Sifra != value))
				{
					this.OnSifraChanging(value);
					this.SendPropertyChanging();
					this._Sifra = value;
					this.SendPropertyChanged("Sifra");
					this.OnSifraChanged();
				}
			}
		}
		
		[global::System.Runtime.Serialization.IgnoreDataMember]
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="korisnik_fk", Storage="_Problemi", ThisKey="Id,Id", OtherKey="Korisnik_id,Korisnik_id", DeleteRule="NO ACTION")]
		public EntitySet<Problemi> Problemi
		{
			get
			{
				return this._Problemi;
			}
			set
			{
				this._Problemi.Assign(value);
			}
		}
		
		[global::System.Runtime.Serialization.IgnoreDataMember]
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="korisnik_fk", Storage="_Putovanja", ThisKey="Id,Id", OtherKey="Korisnik_id,Korisnik_id", DeleteRule="NO ACTION")]
		public EntitySet<Putovanja> Putovanja
		{
			get
			{
				return this._Putovanja;
			}
			set
			{
				this._Putovanja.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Problemi(Problemi entity)
		{
			this.SendPropertyChanging();
			entity.Korisnici = this;
		}
		
		private void detach_Problemi(Problemi entity)
		{
			this.SendPropertyChanging();
			entity.Korisnici = null;
		}
		
		private void attach_Putovanja(Putovanja entity)
		{
			this.SendPropertyChanging();
			entity.Korisnici = this;
		}
		
		private void detach_Putovanja(Putovanja entity)
		{
			this.SendPropertyChanging();
			entity.Korisnici = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute()]
	public partial class Problemi : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _Korisnik_id;
		
		private string _Opis;
		
		private System.DateTime _Datum;
		
		private EntityRef<Korisnici> _Korisnici;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnKorisnik_idChanging(int value);
    partial void OnKorisnik_idChanged();
    partial void OnOpisChanging(string value);
    partial void OnOpisChanged();
    partial void OnDatumChanging(System.DateTime value);
    partial void OnDatumChanged();
    #endregion
		
		public Problemi()
		{
			this._Korisnici = default(EntityRef<Korisnici>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Korisnik_id", DbType="Int NOT NULL")]
		public int Korisnik_id
		{
			get
			{
				return this._Korisnik_id;
			}
			set
			{
				if ((this._Korisnik_id != value))
				{
					if ((this._Korisnici.HasLoadedOrAssignedValue || this._Korisnici.HasLoadedOrAssignedValue))
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnKorisnik_idChanging(value);
					this.SendPropertyChanging();
					this._Korisnik_id = value;
					this.SendPropertyChanged("Korisnik_id");
					this.OnKorisnik_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Opis", DbType="NVarChar(500) NOT NULL", CanBeNull=false)]
		public string Opis
		{
			get
			{
				return this._Opis;
			}
			set
			{
				if ((this._Opis != value))
				{
					this.OnOpisChanging(value);
					this.SendPropertyChanging();
					this._Opis = value;
					this.SendPropertyChanged("Opis");
					this.OnOpisChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Datum", DbType="DateTime NOT NULL")]
		public System.DateTime Datum
		{
			get
			{
				return this._Datum;
			}
			set
			{
				if ((this._Datum != value))
				{
					this.OnDatumChanging(value);
					this.SendPropertyChanging();
					this._Datum = value;
					this.SendPropertyChanged("Datum");
					this.OnDatumChanged();
				}
			}
		}
		
		[global::System.Runtime.Serialization.IgnoreDataMember]
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="korisnik_fk", Storage="_Korisnici", ThisKey="Korisnik_id,Korisnik_id", OtherKey="Id,Id", IsForeignKey=true)]
		public Korisnici Korisnici
		{
			get
			{
				return this._Korisnici.Entity;
			}
			set
			{
				Korisnici previousValue = this._Korisnici.Entity;
				if (((previousValue != value) 
							|| (this._Korisnici.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Korisnici.Entity = null;
						previousValue.Problemi.Remove(this);
					}
					this._Korisnici.Entity = value;
					if ((value != null))
					{
						value.Problemi.Add(this);
						this._Korisnik_id = value.Id;
						this._Korisnik_id = value.Id;
					}
					else
					{
						this._Korisnik_id = default(int);
						this._Korisnik_id = default(int);
					}
					this.SendPropertyChanged("Korisnici");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute()]
	public partial class Putovanja : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Naziv;
		
		private string _Planeta;
		
		private int _Korisnik_id;
		
		private EntityRef<Korisnici> _Korisnici;
		
		private EntitySet<Atrakcije> _Atrakcije;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNazivChanging(string value);
    partial void OnNazivChanged();
    partial void OnPlanetaChanging(string value);
    partial void OnPlanetaChanged();
    partial void OnKorisnik_idChanging(int value);
    partial void OnKorisnik_idChanged();
    #endregion
		
		public Putovanja()
		{
			this._Korisnici = default(EntityRef<Korisnici>);
			this._Atrakcije = new EntitySet<Atrakcije>(new Action<Atrakcije>(this.attach_Atrakcije), new Action<Atrakcije>(this.detach_Atrakcije));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Naziv", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Naziv
		{
			get
			{
				return this._Naziv;
			}
			set
			{
				if ((this._Naziv != value))
				{
					this.OnNazivChanging(value);
					this.SendPropertyChanging();
					this._Naziv = value;
					this.SendPropertyChanged("Naziv");
					this.OnNazivChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Planeta", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Planeta
		{
			get
			{
				return this._Planeta;
			}
			set
			{
				if ((this._Planeta != value))
				{
					this.OnPlanetaChanging(value);
					this.SendPropertyChanging();
					this._Planeta = value;
					this.SendPropertyChanged("Planeta");
					this.OnPlanetaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Korisnik_id", DbType="Int NOT NULL")]
		public int Korisnik_id
		{
			get
			{
				return this._Korisnik_id;
			}
			set
			{
				if ((this._Korisnik_id != value))
				{
					if ((this._Korisnici.HasLoadedOrAssignedValue || this._Korisnici.HasLoadedOrAssignedValue))
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnKorisnik_idChanging(value);
					this.SendPropertyChanging();
					this._Korisnik_id = value;
					this.SendPropertyChanged("Korisnik_id");
					this.OnKorisnik_idChanged();
				}
			}
		}
		
		[global::System.Runtime.Serialization.IgnoreDataMember]
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="korisnik_fk", Storage="_Korisnici", ThisKey="Korisnik_id,Korisnik_id", OtherKey="Id,Id", IsForeignKey=true)]
		public Korisnici Korisnici
		{
			get
			{
				return this._Korisnici.Entity;
			}
			set
			{
				Korisnici previousValue = this._Korisnici.Entity;
				if (((previousValue != value) 
							|| (this._Korisnici.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Korisnici.Entity = null;
						previousValue.Putovanja.Remove(this);
					}
					this._Korisnici.Entity = value;
					if ((value != null))
					{
						value.Putovanja.Add(this);
						this._Korisnik_id = value.Id;
						this._Korisnik_id = value.Id;
					}
					else
					{
						this._Korisnik_id = default(int);
						this._Korisnik_id = default(int);
					}
					this.SendPropertyChanged("Korisnici");
				}
			}
		}
		
		[global::System.Runtime.Serialization.IgnoreDataMember]
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="putovanja_fk", Storage="_Atrakcije", ThisKey="Id", OtherKey="Id_putovanja", DeleteRule="NO ACTION")]
		public EntitySet<Atrakcije> Atrakcije
		{
			get
			{
				return this._Atrakcije;
			}
			set
			{
				this._Atrakcije.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Atrakcije(Atrakcije entity)
		{
			this.SendPropertyChanging();
			entity.Putovanja = this;
		}
		
		private void detach_Atrakcije(Atrakcije entity)
		{
			this.SendPropertyChanging();
			entity.Putovanja = null;
		}
	}
}
#pragma warning restore 1591
