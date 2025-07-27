declare @TableName varchar(50) = 'Recipe'

select concat('@', c.name, ' ', ty.name, ' ',
    case 
        when ty.name in ('varchar', 'char', 'nvarchar', 'nchar') then concat('(', c.max_length, ')') 
        else '' 
    end,
    case 
        when t.name + 'id' = c.name then ' output' 
        else '' 
    end,
    ','
)
from sys.columns c
join sys.tables t on c.object_id = t.object_id
join sys.types ty on c.user_type_id = ty.user_type_id
where t.name = @TableName
and c.is_computed = 0


declare @InsertList varchar(max) = ''

select @InsertList = @InsertList + concat(c.name, ', ')
from sys.columns c
join sys.tables t
on c.object_id = t.object_id
where t.name = @TableName
and c.is_computed = 0
and c.name <> t.name + 'Id';

select @InsertList

select @InsertList = ''

select @InsertList = @InsertList +  concat('@', c.name, ', ')
from sys.columns c
join sys.tables t on c.object_id = t.object_id
where t.name = @TableName
and c.is_computed = 0
and c.name <> t.name + 'Id'

select @InsertList

select concat(c.name, ' = ', '@', c.name, ', ')
from sys.columns c
join sys.tables t on c.object_id = t.object_id
where t.name = @TableName
and c.is_computed = 0
and c.name <> t.name + 'Id'