﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CMT.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="CMT")]
	public partial class DatabaseDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertChamp(Champ instance);
    partial void UpdateChamp(Champ instance);
    partial void DeleteChamp(Champ instance);
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    partial void InsertGroup(Group instance);
    partial void UpdateGroup(Group instance);
    partial void DeleteGroup(Group instance);
    partial void InsertGroupUser(GroupUser instance);
    partial void UpdateGroupUser(GroupUser instance);
    partial void DeleteGroupUser(GroupUser instance);
    partial void InsertMatch(Match instance);
    partial void UpdateMatch(Match instance);
    partial void DeleteMatch(Match instance);
    #endregion
		
		public DatabaseDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["CMTConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Champ> Champs
		{
			get
			{
				return this.GetTable<Champ>();
			}
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
		
		public System.Data.Linq.Table<Group> Groups
		{
			get
			{
				return this.GetTable<Group>();
			}
		}
		
		public System.Data.Linq.Table<GroupUser> GroupUsers
		{
			get
			{
				return this.GetTable<GroupUser>();
			}
		}
		
		public System.Data.Linq.Table<Match> Matches
		{
			get
			{
				return this.GetTable<Match>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Champs")]
	public partial class Champ : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
		private System.DateTime _Created;
		
		private int _CreatedBy;
		
		private System.Nullable<System.DateTime> _Finished;
		
		private EntityRef<Group> _Group;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnCreatedChanging(System.DateTime value);
    partial void OnCreatedChanged();
    partial void OnCreatedByChanging(int value);
    partial void OnCreatedByChanged();
    partial void OnFinishedChanging(System.Nullable<System.DateTime> value);
    partial void OnFinishedChanged();
    #endregion
		
		public Champ()
		{
			this._Group = default(EntityRef<Group>);
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Created", DbType="DateTime NOT NULL")]
		public System.DateTime Created
		{
			get
			{
				return this._Created;
			}
			set
			{
				if ((this._Created != value))
				{
					this.OnCreatedChanging(value);
					this.SendPropertyChanging();
					this._Created = value;
					this.SendPropertyChanged("Created");
					this.OnCreatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedBy", DbType="Int NOT NULL")]
		public int CreatedBy
		{
			get
			{
				return this._CreatedBy;
			}
			set
			{
				if ((this._CreatedBy != value))
				{
					this.OnCreatedByChanging(value);
					this.SendPropertyChanging();
					this._CreatedBy = value;
					this.SendPropertyChanged("CreatedBy");
					this.OnCreatedByChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Finished", DbType="DateTime")]
		public System.Nullable<System.DateTime> Finished
		{
			get
			{
				return this._Finished;
			}
			set
			{
				if ((this._Finished != value))
				{
					this.OnFinishedChanging(value);
					this.SendPropertyChanging();
					this._Finished = value;
					this.SendPropertyChanged("Finished");
					this.OnFinishedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Champ_Group", Storage="_Group", ThisKey="Id", OtherKey="Id", IsUnique=true, IsForeignKey=false)]
		public Group Group
		{
			get
			{
				return this._Group.Entity;
			}
			set
			{
				Group previousValue = this._Group.Entity;
				if (((previousValue != value) 
							|| (this._Group.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Group.Entity = null;
						previousValue.Champ = null;
					}
					this._Group.Entity = value;
					if ((value != null))
					{
						value.Champ = this;
					}
					this.SendPropertyChanged("Group");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Users")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _UserName;
		
		private string _Password;
		
		private string _Email;
		
		private string _DisplayName;
		
		private int _Wins;
		
		private int _Losses;
		
		private int _Drafts;
		
		private int _Rating;
		
		private System.Nullable<System.DateTime> _Created;
		
		private System.Nullable<bool> _Administrator;
		
		private bool _Deleted;
		
		private EntitySet<GroupUser> _GroupUsers;
		
		private EntitySet<Match> _Matches;
		
		private EntitySet<Match> _Matches1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnUserNameChanging(string value);
    partial void OnUserNameChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnDisplayNameChanging(string value);
    partial void OnDisplayNameChanged();
    partial void OnWinsChanging(int value);
    partial void OnWinsChanged();
    partial void OnLossesChanging(int value);
    partial void OnLossesChanged();
    partial void OnDraftsChanging(int value);
    partial void OnDraftsChanged();
    partial void OnRatingChanging(int value);
    partial void OnRatingChanged();
    partial void OnCreatedChanging(System.Nullable<System.DateTime> value);
    partial void OnCreatedChanged();
    partial void OnAdministratorChanging(System.Nullable<bool> value);
    partial void OnAdministratorChanged();
    partial void OnDeletedChanging(bool value);
    partial void OnDeletedChanged();
    #endregion
		
		public User()
		{
			this._GroupUsers = new EntitySet<GroupUser>(new Action<GroupUser>(this.attach_GroupUsers), new Action<GroupUser>(this.detach_GroupUsers));
			this._Matches = new EntitySet<Match>(new Action<Match>(this.attach_Matches), new Action<Match>(this.detach_Matches));
			this._Matches1 = new EntitySet<Match>(new Action<Match>(this.attach_Matches1), new Action<Match>(this.detach_Matches1));
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this.OnUserNameChanging(value);
					this.SendPropertyChanging();
					this._UserName = value;
					this.SendPropertyChanged("UserName");
					this.OnUserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DisplayName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string DisplayName
		{
			get
			{
				return this._DisplayName;
			}
			set
			{
				if ((this._DisplayName != value))
				{
					this.OnDisplayNameChanging(value);
					this.SendPropertyChanging();
					this._DisplayName = value;
					this.SendPropertyChanged("DisplayName");
					this.OnDisplayNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Wins", DbType="Int NOT NULL")]
		public int Wins
		{
			get
			{
				return this._Wins;
			}
			set
			{
				if ((this._Wins != value))
				{
					this.OnWinsChanging(value);
					this.SendPropertyChanging();
					this._Wins = value;
					this.SendPropertyChanged("Wins");
					this.OnWinsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Losses", DbType="Int NOT NULL")]
		public int Losses
		{
			get
			{
				return this._Losses;
			}
			set
			{
				if ((this._Losses != value))
				{
					this.OnLossesChanging(value);
					this.SendPropertyChanging();
					this._Losses = value;
					this.SendPropertyChanged("Losses");
					this.OnLossesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Drafts", DbType="Int NOT NULL")]
		public int Drafts
		{
			get
			{
				return this._Drafts;
			}
			set
			{
				if ((this._Drafts != value))
				{
					this.OnDraftsChanging(value);
					this.SendPropertyChanging();
					this._Drafts = value;
					this.SendPropertyChanged("Drafts");
					this.OnDraftsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Rating", DbType="Int NOT NULL")]
		public int Rating
		{
			get
			{
				return this._Rating;
			}
			set
			{
				if ((this._Rating != value))
				{
					this.OnRatingChanging(value);
					this.SendPropertyChanging();
					this._Rating = value;
					this.SendPropertyChanged("Rating");
					this.OnRatingChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Created", DbType="DateTime")]
		public System.Nullable<System.DateTime> Created
		{
			get
			{
				return this._Created;
			}
			set
			{
				if ((this._Created != value))
				{
					this.OnCreatedChanging(value);
					this.SendPropertyChanging();
					this._Created = value;
					this.SendPropertyChanged("Created");
					this.OnCreatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Administrator", DbType="Bit")]
		public System.Nullable<bool> Administrator
		{
			get
			{
				return this._Administrator;
			}
			set
			{
				if ((this._Administrator != value))
				{
					this.OnAdministratorChanging(value);
					this.SendPropertyChanging();
					this._Administrator = value;
					this.SendPropertyChanged("Administrator");
					this.OnAdministratorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Deleted", DbType="Bit NOT NULL")]
		public bool Deleted
		{
			get
			{
				return this._Deleted;
			}
			set
			{
				if ((this._Deleted != value))
				{
					this.OnDeletedChanging(value);
					this.SendPropertyChanging();
					this._Deleted = value;
					this.SendPropertyChanged("Deleted");
					this.OnDeletedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_GroupUser", Storage="_GroupUsers", ThisKey="Id", OtherKey="UserId")]
		public EntitySet<GroupUser> GroupUsers
		{
			get
			{
				return this._GroupUsers;
			}
			set
			{
				this._GroupUsers.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Match", Storage="_Matches", ThisKey="Id", OtherKey="SourceUserId")]
		public EntitySet<Match> Matches
		{
			get
			{
				return this._Matches;
			}
			set
			{
				this._Matches.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Match1", Storage="_Matches1", ThisKey="Id", OtherKey="TargetUserId")]
		public EntitySet<Match> Matches1
		{
			get
			{
				return this._Matches1;
			}
			set
			{
				this._Matches1.Assign(value);
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
		
		private void attach_GroupUsers(GroupUser entity)
		{
			this.SendPropertyChanging();
			entity.User = this;
		}
		
		private void detach_GroupUsers(GroupUser entity)
		{
			this.SendPropertyChanging();
			entity.User = null;
		}
		
		private void attach_Matches(Match entity)
		{
			this.SendPropertyChanging();
			entity.User = this;
		}
		
		private void detach_Matches(Match entity)
		{
			this.SendPropertyChanging();
			entity.User = null;
		}
		
		private void attach_Matches1(Match entity)
		{
			this.SendPropertyChanging();
			entity.User1 = this;
		}
		
		private void detach_Matches1(Match entity)
		{
			this.SendPropertyChanging();
			entity.User1 = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Groups")]
	public partial class Group : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _ChampId;
		
		private EntitySet<GroupUser> _GroupUsers;
		
		private EntityRef<Champ> _Champ;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnChampIdChanging(int value);
    partial void OnChampIdChanged();
    #endregion
		
		public Group()
		{
			this._GroupUsers = new EntitySet<GroupUser>(new Action<GroupUser>(this.attach_GroupUsers), new Action<GroupUser>(this.detach_GroupUsers));
			this._Champ = default(EntityRef<Champ>);
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
					if (this._Champ.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChampId", DbType="Int NOT NULL")]
		public int ChampId
		{
			get
			{
				return this._ChampId;
			}
			set
			{
				if ((this._ChampId != value))
				{
					this.OnChampIdChanging(value);
					this.SendPropertyChanging();
					this._ChampId = value;
					this.SendPropertyChanged("ChampId");
					this.OnChampIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Group_GroupUser", Storage="_GroupUsers", ThisKey="Id", OtherKey="GroupId")]
		public EntitySet<GroupUser> GroupUsers
		{
			get
			{
				return this._GroupUsers;
			}
			set
			{
				this._GroupUsers.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Champ_Group", Storage="_Champ", ThisKey="Id", OtherKey="Id", IsForeignKey=true)]
		public Champ Champ
		{
			get
			{
				return this._Champ.Entity;
			}
			set
			{
				Champ previousValue = this._Champ.Entity;
				if (((previousValue != value) 
							|| (this._Champ.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Champ.Entity = null;
						previousValue.Group = null;
					}
					this._Champ.Entity = value;
					if ((value != null))
					{
						value.Group = this;
						this._Id = value.Id;
					}
					else
					{
						this._Id = default(int);
					}
					this.SendPropertyChanged("Champ");
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
		
		private void attach_GroupUsers(GroupUser entity)
		{
			this.SendPropertyChanging();
			entity.Group = this;
		}
		
		private void detach_GroupUsers(GroupUser entity)
		{
			this.SendPropertyChanging();
			entity.Group = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.GroupUsers")]
	public partial class GroupUser : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _GroupId;
		
		private int _UserId;
		
		private EntityRef<Group> _Group;
		
		private EntityRef<User> _User;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnGroupIdChanging(int value);
    partial void OnGroupIdChanged();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    #endregion
		
		public GroupUser()
		{
			this._Group = default(EntityRef<Group>);
			this._User = default(EntityRef<User>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GroupId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int GroupId
		{
			get
			{
				return this._GroupId;
			}
			set
			{
				if ((this._GroupId != value))
				{
					if (this._Group.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnGroupIdChanging(value);
					this.SendPropertyChanging();
					this._GroupId = value;
					this.SendPropertyChanged("GroupId");
					this.OnGroupIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					if (this._User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Group_GroupUser", Storage="_Group", ThisKey="GroupId", OtherKey="Id", IsForeignKey=true)]
		public Group Group
		{
			get
			{
				return this._Group.Entity;
			}
			set
			{
				Group previousValue = this._Group.Entity;
				if (((previousValue != value) 
							|| (this._Group.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Group.Entity = null;
						previousValue.GroupUsers.Remove(this);
					}
					this._Group.Entity = value;
					if ((value != null))
					{
						value.GroupUsers.Add(this);
						this._GroupId = value.Id;
					}
					else
					{
						this._GroupId = default(int);
					}
					this.SendPropertyChanged("Group");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_GroupUser", Storage="_User", ThisKey="UserId", OtherKey="Id", IsForeignKey=true)]
		public User User
		{
			get
			{
				return this._User.Entity;
			}
			set
			{
				User previousValue = this._User.Entity;
				if (((previousValue != value) 
							|| (this._User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._User.Entity = null;
						previousValue.GroupUsers.Remove(this);
					}
					this._User.Entity = value;
					if ((value != null))
					{
						value.GroupUsers.Add(this);
						this._UserId = value.Id;
					}
					else
					{
						this._UserId = default(int);
					}
					this.SendPropertyChanged("User");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Matches")]
	public partial class Match : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _SourceUserId;
		
		private int _TargetUserId;
		
		private int _SourceScore;
		
		private int _TargetScore;
		
		private System.Nullable<System.DateTime> _Date;
		
		private EntityRef<User> _User;
		
		private EntityRef<User> _User1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnSourceUserIdChanging(int value);
    partial void OnSourceUserIdChanged();
    partial void OnTargetUserIdChanging(int value);
    partial void OnTargetUserIdChanged();
    partial void OnSourceScoreChanging(int value);
    partial void OnSourceScoreChanged();
    partial void OnTargetScoreChanging(int value);
    partial void OnTargetScoreChanged();
    partial void OnDateChanging(System.Nullable<System.DateTime> value);
    partial void OnDateChanged();
    #endregion
		
		public Match()
		{
			this._User = default(EntityRef<User>);
			this._User1 = default(EntityRef<User>);
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SourceUserId", DbType="Int NOT NULL")]
		public int SourceUserId
		{
			get
			{
				return this._SourceUserId;
			}
			set
			{
				if ((this._SourceUserId != value))
				{
					if (this._User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnSourceUserIdChanging(value);
					this.SendPropertyChanging();
					this._SourceUserId = value;
					this.SendPropertyChanged("SourceUserId");
					this.OnSourceUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TargetUserId", DbType="Int NOT NULL")]
		public int TargetUserId
		{
			get
			{
				return this._TargetUserId;
			}
			set
			{
				if ((this._TargetUserId != value))
				{
					if (this._User1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnTargetUserIdChanging(value);
					this.SendPropertyChanging();
					this._TargetUserId = value;
					this.SendPropertyChanged("TargetUserId");
					this.OnTargetUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SourceScore", DbType="Int NOT NULL")]
		public int SourceScore
		{
			get
			{
				return this._SourceScore;
			}
			set
			{
				if ((this._SourceScore != value))
				{
					this.OnSourceScoreChanging(value);
					this.SendPropertyChanging();
					this._SourceScore = value;
					this.SendPropertyChanged("SourceScore");
					this.OnSourceScoreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TargetScore", DbType="Int NOT NULL")]
		public int TargetScore
		{
			get
			{
				return this._TargetScore;
			}
			set
			{
				if ((this._TargetScore != value))
				{
					this.OnTargetScoreChanging(value);
					this.SendPropertyChanging();
					this._TargetScore = value;
					this.SendPropertyChanged("TargetScore");
					this.OnTargetScoreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date", DbType="DateTime")]
		public System.Nullable<System.DateTime> Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				if ((this._Date != value))
				{
					this.OnDateChanging(value);
					this.SendPropertyChanging();
					this._Date = value;
					this.SendPropertyChanged("Date");
					this.OnDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Match", Storage="_User", ThisKey="SourceUserId", OtherKey="Id", IsForeignKey=true)]
		public User User
		{
			get
			{
				return this._User.Entity;
			}
			set
			{
				User previousValue = this._User.Entity;
				if (((previousValue != value) 
							|| (this._User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._User.Entity = null;
						previousValue.Matches.Remove(this);
					}
					this._User.Entity = value;
					if ((value != null))
					{
						value.Matches.Add(this);
						this._SourceUserId = value.Id;
					}
					else
					{
						this._SourceUserId = default(int);
					}
					this.SendPropertyChanged("User");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Match1", Storage="_User1", ThisKey="TargetUserId", OtherKey="Id", IsForeignKey=true)]
		public User User1
		{
			get
			{
				return this._User1.Entity;
			}
			set
			{
				User previousValue = this._User1.Entity;
				if (((previousValue != value) 
							|| (this._User1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._User1.Entity = null;
						previousValue.Matches1.Remove(this);
					}
					this._User1.Entity = value;
					if ((value != null))
					{
						value.Matches1.Add(this);
						this._TargetUserId = value.Id;
					}
					else
					{
						this._TargetUserId = default(int);
					}
					this.SendPropertyChanged("User1");
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
}
#pragma warning restore 1591
