ALTER TABLE [Users]
ADD CONSTRAINT CheckPassword CHECK (LEN([Password]) >= 5)