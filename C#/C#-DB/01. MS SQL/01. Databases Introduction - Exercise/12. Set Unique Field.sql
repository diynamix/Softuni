ALTER TABLE [Users]
	DROP PK_UserCompositeIdUsername

ALTER TABLE [Users]
	ADD CONSTRAINT PK__Users PRIMARY KEY (Id) ;

ALTER TABLE [Users]
	ADD CONSTRAINT CheckUsernameLength CHECK (LEN(Username) >= 3)