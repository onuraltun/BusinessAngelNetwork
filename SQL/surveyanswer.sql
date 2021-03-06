USE [MersinBAN]
GO
/****** Object:  Table [dbo].[SURVEY_QUESTION_ANSWER]    Script Date: 09/18/2009 11:21:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SURVEY_QUESTION_ANSWER](
	[SurveyAnswerID] [uniqueidentifier] NOT NULL,
	[SurveyID] [uniqueidentifier] NOT NULL,
	[SurveyQuestionOptionID] [uniqueidentifier] NOT NULL,
	[Answer] [nvarchar](max) COLLATE Turkish_CI_AS NOT NULL,
	[MemberID] [int] NOT NULL,
	[GuestID] [nvarchar](max) COLLATE Turkish_CI_AS NULL,
 CONSTRAINT [PK_SURVEY_QUESTION_ANSWER] PRIMARY KEY CLUSTERED 
(
	[SurveyAnswerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
