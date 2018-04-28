--select * from 归并前料件清单

declare @新电子帐册号 varchar(15)
set @新电子帐册号='20170988'
declare @旧电子帐册号 varchar(15)
set @旧电子帐册号='20170912'
declare @新归并后料件id int
declare 归并后料件清单_Cursor cursor for
select * from 归并后料件清单 where 电子帐册号=@旧电子帐册号
declare @归并后料件id int
declare @电子帐册号 varchar(15)
declare @序号 int
declare @产品编号 varchar(15)
declare @商品编码 varchar(20)
declare @商品名称 varchar(60)
declare @商品规格 varchar(60)
declare @产销国 varchar(15)
declare @计量单位 varchar(10)
declare @法定单位 varchar(10)
declare @换算因子 float
declare @单价 money
declare @损耗率 float
declare @币种 varchar(10)
declare @主料 char(10)
declare @四位大类序号 int
           
OPEN 归并后料件清单_Cursor
--取第一行的cDevelopCodeNew值给变量
fetch next from 归并后料件清单_Cursor into @归并后料件id,@电子帐册号,@序号,@产品编号,@商品编码,@商品名称,@商品规格
		,@产销国,@计量单位,@法定单位,@换算因子,@单价,@损耗率,@币种,@主料,@四位大类序号   --取得游标的第一行数据
  --开始循环
  while(@@fetch_status=0)   --@@fetch_status=0判断取数是否存在
   begin  
      --生成新帐册的归并后料件清单
      insert into 归并后料件清单(电子帐册号,序号,产品编号,商品编码,商品名称,商品规格
		,产销国,计量单位,法定单位,换算因子,单价,损耗率,币种,主料,四位大类序号)
		values (@新电子帐册号,@序号,@产品编号,@商品编码,@商品名称,@商品规格
		,@产销国,@计量单位,@法定单位,@换算因子,@单价,@损耗率,@币种,@主料,@四位大类序号)
		--获取新生成的归并后料件ID
		select @新归并后料件id=@@IDENTITY  
		--归并前料件清单游标
		declare 归并前料件清单_Cursor cursor for
			select * from 归并前料件清单 where 归并后料件id=@归并后料件id
		declare @归并前料件id_D int
		declare @归并后料件id_D int
		declare @产品编号_D varchar(15)
		declare @序号_D int
		declare @商品规格_D varchar(60)
		declare @对应编号_D char(10)
		declare @单价_D money	
		OPEN 归并前料件清单_Cursor
		--取第一行的cDevelopCodeNew值给变量
		fetch next from 归并前料件清单_Cursor into @归并前料件id_D,@归并后料件id_D,@产品编号_D,@序号_D,@商品规格_D,
					@对应编号_D,@单价_D   --取得游标的第一行数据
		while(@@fetch_status=0)   --@@fetch_status=0判断取数是否存在
		begin 
			insert into 归并前料件清单(归并后料件id,产品编号,序号,商品规格,对应编号,单价) 
			values (@新归并后料件id,@产品编号_D,@序号_D,@商品规格_D,@对应编号_D,@单价_D)
			--游标移至下一行
			 fetch next from 归并前料件清单_Cursor into @归并前料件id_D,@归并后料件id_D,@产品编号_D,@序号_D,@商品规格_D,
					@对应编号_D,@单价_D
		end
		--循环结束，删除游标
		close 归并前料件清单_Cursor
		deallocate 归并前料件清单_Cursor
  
    --游标移至下一行
     fetch next from 归并后料件清单_Cursor into @归并后料件id,@电子帐册号,@序号,@产品编号,@商品编码,@商品名称,@商品规格
		,@产销国,@计量单位,@法定单位,@换算因子,@单价,@损耗率,@币种,@主料,@四位大类序号
  end
 
  --循环结束，删除游标
  close 归并后料件清单_Cursor
  deallocate 归并后料件清单_Cursor