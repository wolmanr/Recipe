
--replace login name // and // password// with the secret value from the vault
-- IMPORTANT crate login in master
--use Master
create login // loginname/ with password = '//password//'

impotant switch to RECIPEDB
create user dev_user from login //loginname//


alter role db_datareader add member dev_recipeuser
alter role db_datawriter add member dev_recipeuser

