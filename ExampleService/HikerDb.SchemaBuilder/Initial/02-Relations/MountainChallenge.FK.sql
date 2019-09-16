IF NOT EXISTS
(
    SELECT *
    FROM   [INFORMATION_SCHEMA].[REFERENTIAL_CONSTRAINTS]
    WHERE  [CONSTRAINT_NAME] = 'FK_MountainChallenge2Mountain'
)
BEGIN
    ALTER TABLE [HIKE].[MountainChallenge]
    WITH CHECK
    ADD CONSTRAINT [FK_MountainChallenge2Mountain] FOREIGN KEY([MountainId]) REFERENCES [HIKE].[Mountain]([Id]);
END;

ALTER TABLE [HIKE].[MountainChallenge] CHECK CONSTRAINT [FK_MountainChallenge2Mountain];

IF NOT EXISTS
(
    SELECT *
    FROM   [INFORMATION_SCHEMA].[REFERENTIAL_CONSTRAINTS]
    WHERE  [CONSTRAINT_NAME] = 'FK_MountainChallenge2Challenge'
)
BEGIN
    ALTER TABLE [HIKE].[MountainChallenge]
    WITH CHECK
    ADD CONSTRAINT [FK_MountainChallenge2Challenge] FOREIGN KEY([ChallengeId]) REFERENCES [HIKE].[Challenge]([Id]);
END;

ALTER TABLE [HIKE].[MountainChallenge] CHECK CONSTRAINT [FK_MountainChallenge2Challenge];