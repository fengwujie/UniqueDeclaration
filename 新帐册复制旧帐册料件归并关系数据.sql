--select * from �鲢ǰ�ϼ��嵥

declare @�µ����ʲ�� varchar(15)
set @�µ����ʲ��='20170988'
declare @�ɵ����ʲ�� varchar(15)
set @�ɵ����ʲ��='20170912'
declare @�¹鲢���ϼ�id int
declare �鲢���ϼ��嵥_Cursor cursor for
select * from �鲢���ϼ��嵥 where �����ʲ��=@�ɵ����ʲ��
declare @�鲢���ϼ�id int
declare @�����ʲ�� varchar(15)
declare @��� int
declare @��Ʒ��� varchar(15)
declare @��Ʒ���� varchar(20)
declare @��Ʒ���� varchar(60)
declare @��Ʒ��� varchar(60)
declare @������ varchar(15)
declare @������λ varchar(10)
declare @������λ varchar(10)
declare @�������� float
declare @���� money
declare @����� float
declare @���� varchar(10)
declare @���� char(10)
declare @��λ������� int
           
OPEN �鲢���ϼ��嵥_Cursor
--ȡ��һ�е�cDevelopCodeNewֵ������
fetch next from �鲢���ϼ��嵥_Cursor into @�鲢���ϼ�id,@�����ʲ��,@���,@��Ʒ���,@��Ʒ����,@��Ʒ����,@��Ʒ���
		,@������,@������λ,@������λ,@��������,@����,@�����,@����,@����,@��λ�������   --ȡ���α�ĵ�һ������
  --��ʼѭ��
  while(@@fetch_status=0)   --@@fetch_status=0�ж�ȡ���Ƿ����
   begin  
      --�������ʲ�Ĺ鲢���ϼ��嵥
      insert into �鲢���ϼ��嵥(�����ʲ��,���,��Ʒ���,��Ʒ����,��Ʒ����,��Ʒ���
		,������,������λ,������λ,��������,����,�����,����,����,��λ�������)
		values (@�µ����ʲ��,@���,@��Ʒ���,@��Ʒ����,@��Ʒ����,@��Ʒ���
		,@������,@������λ,@������λ,@��������,@����,@�����,@����,@����,@��λ�������)
		--��ȡ�����ɵĹ鲢���ϼ�ID
		select @�¹鲢���ϼ�id=@@IDENTITY  
		--�鲢ǰ�ϼ��嵥�α�
		declare �鲢ǰ�ϼ��嵥_Cursor cursor for
			select * from �鲢ǰ�ϼ��嵥 where �鲢���ϼ�id=@�鲢���ϼ�id
		declare @�鲢ǰ�ϼ�id_D int
		declare @�鲢���ϼ�id_D int
		declare @��Ʒ���_D varchar(15)
		declare @���_D int
		declare @��Ʒ���_D varchar(60)
		declare @��Ӧ���_D char(10)
		declare @����_D money	
		OPEN �鲢ǰ�ϼ��嵥_Cursor
		--ȡ��һ�е�cDevelopCodeNewֵ������
		fetch next from �鲢ǰ�ϼ��嵥_Cursor into @�鲢ǰ�ϼ�id_D,@�鲢���ϼ�id_D,@��Ʒ���_D,@���_D,@��Ʒ���_D,
					@��Ӧ���_D,@����_D   --ȡ���α�ĵ�һ������
		while(@@fetch_status=0)   --@@fetch_status=0�ж�ȡ���Ƿ����
		begin 
			insert into �鲢ǰ�ϼ��嵥(�鲢���ϼ�id,��Ʒ���,���,��Ʒ���,��Ӧ���,����) 
			values (@�¹鲢���ϼ�id,@��Ʒ���_D,@���_D,@��Ʒ���_D,@��Ӧ���_D,@����_D)
			--�α�������һ��
			 fetch next from �鲢ǰ�ϼ��嵥_Cursor into @�鲢ǰ�ϼ�id_D,@�鲢���ϼ�id_D,@��Ʒ���_D,@���_D,@��Ʒ���_D,
					@��Ӧ���_D,@����_D
		end
		--ѭ��������ɾ���α�
		close �鲢ǰ�ϼ��嵥_Cursor
		deallocate �鲢ǰ�ϼ��嵥_Cursor
  
    --�α�������һ��
     fetch next from �鲢���ϼ��嵥_Cursor into @�鲢���ϼ�id,@�����ʲ��,@���,@��Ʒ���,@��Ʒ����,@��Ʒ����,@��Ʒ���
		,@������,@������λ,@������λ,@��������,@����,@�����,@����,@����,@��λ�������
  end
 
  --ѭ��������ɾ���α�
  close �鲢���ϼ��嵥_Cursor
  deallocate �鲢���ϼ��嵥_Cursor