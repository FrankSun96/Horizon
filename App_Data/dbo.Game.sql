CREATE TABLE [dbo].[Game] (
    [GameID]            SMALLINT     NOT NULL,
    [GameTypeID]        SMALLINT     NOT NULL,
    [GameProducerID]    SMALLINT     NULL,
    [GameName]          VARCHAR (30) NOT NULL,
    [GameConfiguration] VARCHAR (30) NOT NULL,
    [Introduction]      VARCHAR (30) NOT NULL,
    [GameImg]           VARCHAR (30) NOT NULL,
    [Count]             BIGINT       DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([GameID] ASC)
);

