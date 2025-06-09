
--replace login name // and // password// with the secret value from the vault
-- IMPORTANT crate login in master
--use Master
create login dev_recipelogin with password = 'STArts234(&^'

--impotant switch to RECIPEDB
create user dev_recipeuser from login dev_recipelogin


alter role db_datareader add member dev_recipeuser
alter role db_datawriter add member dev_recipeuser

