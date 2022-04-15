
/*** Table [dbo].[DepartmentDetails] ***/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DepartmentDetails]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DepartmentDetails](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentCode] [varchar](30) NOT NULL,
	[DepartmentName] [varchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF EXISTS (SELECT object_id FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_AddorUpdateDepartmentDetails]')
	AND type in (N'P', N'PC'))
BEGIN
	DROP PROCEDURE [dbo].[sp_AddorUpdateDepartmentDetails]
END

GO
-- =============================================
-- Author:		Hussain
-- Create date: 15-04-2022
-- Description:	Add or Update the department details
-- =============================================
CREATE PROCEDURE [dbo].[sp_AddorUpdateDepartmentDetails](
@DepartmentId Int = 0,
@DepartmentCode	NVARCHAR(30),
@DepartmentName	NVARCHAR(100),
@IsActive NVARCHAR(1)
)
AS
BEGIN
	IF(@DepartmentId > 0)
		BEGIN
			UPDATE	DepartmentDetails
			SET		DepartmentCode= @DepartmentCode,
					DepartmentName= @DepartmentName,		
					IsActive= @IsActive,
					CreatedDate= GETDATE(),
					ModifiedDate= GETDATE()
			WHERE	DepartmentId= @DepartmentId	
		END
	ELSE
	BEGIN
		INSERT INTO DepartmentDetails
			(
				DepartmentCode,
				DepartmentName,
				IsActive,
				CreatedDate,
				ModifiedDate
			)
			Values
			( 
				@DepartmentCode,
				@DepartmentName,
				@IsActive,	
				GETDATE(),
				GETDATE()
			)
	 END
END
GO

IF EXISTS (SELECT object_id FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetDepartmentDetails]')
	AND type in (N'P', N'PC'))
BEGIN
	DROP PROCEDURE [dbo].[sp_GetDepartmentDetails]
END

GO
-- =============================================
-- Author:		Hussain
-- Create date: 15-04-2022
-- Description:	Get department details by code
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetDepartmentDetails](
@DepartmentCode	NVARCHAR(30) = ''
)
AS
BEGIN
	IF(@DepartmentCode != '')
		BEGIN
			SELECT * FROM DepartmentDetails where DepartmentCode= @DepartmentCode
		END
	ELSE
		BEGIN
			SELECT * FROM DepartmentDetails
		END
END
GO

IF EXISTS (SELECT object_id FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetDepartmentDetailsBySearch]')
	AND type in (N'P', N'PC'))
BEGIN
	DROP PROCEDURE [dbo].[sp_GetDepartmentDetailsBySearch]
END

GO
-- =============================================
-- Author:		Hussain
-- Create date: 15-04-2022
-- Description:	Get department details by search
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetDepartmentDetailsBySearch](
@SearchValue NVARCHAR(30)
)
AS
BEGIN
	SELECT * FROM DepartmentDetails WHERE DepartmentCode LIKE '' + @SearchValue + '%' OR DepartmentName LIKE '' + @SearchValue + '%'
END
GO


