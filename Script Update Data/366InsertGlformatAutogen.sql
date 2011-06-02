
declare @glf numeric
declare @Aglf numeric

select
    @aglf = count(*)
from
    [GLFormat]
where
    [glf_linkgl] = 60
if ( @Aglf = 0 ) 
    begin
        declare @id numeric
  insert into [GLFormat]
          ( [glf_linenumber]
          ,[glf_code]
          ,[glf_name]
          ,[glf_note]
          ,[glf_isdefault]
          ,[glf_accountbook]
          ,[glf_linkgl]
          ,[glf_originator]
          ,[glf_origindate]
          ,[glf_lasteditor]
          ,[glf_lasteditdate]
          ,[glf_canceled]
          ,[glf_cancelperson]
          ,[glf_canceldate]
          )
  values
          ( 1          , -- glf_linenumber - numeric
           'AW'          , -- glf_code - nvarchar(50)
           'Write off �Թ��Ѿ�� (Default)'          , -- glf_name - nvarchar(1000)
           null          , -- glf_note - nvarchar(2000)
           1          , -- glf_isdefault - bit
           null          , -- glf_accountbook - numeric
           60          , -- glf_linkgl - numeric
           null          , -- glf_originator - numeric
           getdate()          , -- glf_origindate - datetime
           null          , -- glf_lasteditor - numeric
           getdate()          , -- glf_lasteditdate - datetime
           null          , -- glf_canceled - bit
           null          , -- glf_cancelperson - numeric
           null  -- glf_canceldate - datetime
          )
  
        set @id = @@IDENTITY
  
        insert into
            [GLFormatItem]
            (
              [glfi_glf]
            , [glfi_linenumber]
            , [glfi_field]
            , [glfi_fieldtype]
            , [glfi_fieldName]
            , [glfi_isdebit]
            , [glfi_acct]
            , [glfi_description]
            , [glfi_mapping]
            , [glfi_note]
            , [glfi_cc]
            )
            select
                @id
              , [glfi_linenumber]
              , [glfi_field]
              , [glfi_fieldtype]
              , case [glfi_fieldtype] when 1 then [ga_name] else isnull([glfi_fieldName],[ga_name]) end [glfi_fieldName]
              , [glfi_isdebit]
              ,  [glfi_acct]
              , [glfi_mapping]
              , [glfi_mapping]
              , [glfi_note]
              , null
            from
                [DefaultGLFormatItem]
                left join [GeneralAccount] on [glfi_field] = ga_id and [glfi_fieldtype] <> 2
            where
                [glfi_linkgl] = 60
    end 

declare @ent  numeric

select
    @ent =  count(*)
from
    [entityautogen]
where
    entity_id = 366
select top 1
    @glf = glf_id
from
    [GLFormat]
where
    [glf_linkgl] = 60


if @ent = 0 
begin
insert into
    [entityautogen]
    (
      [entity_id]
    , [entity_autocodeFormat]
    , [entityauto_glf]
    , [entityauto_desc]
    , [entityauto_config]
        
    )
values
    (
      366     , -- entity_id - numeric
      'AW-"YY"-####'    , -- entity_autocodeFormat - nvarchar(200)
      @glf     , -- entityauto_glf - numeric
      null    , -- entityauto_desc - nvarchar(400)
      3  -- entityauto_config - numeric
        
    )
    
    end