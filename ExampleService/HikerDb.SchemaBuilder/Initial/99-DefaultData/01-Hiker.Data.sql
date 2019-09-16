SET IDENTITY_INSERT [HIKE].[Hiker] ON

INSERT INTO [HIKE].[Hiker] ([Id],[Name],[TrailName],[DateOfBirth],[Experience])
VALUES (1, 'Rose', 'Sasquatch', '10/2/1980',  10);
INSERT INTO [HIKE].[Hiker] ([Id],[Name],[TrailName],[DateOfBirth],[Experience])
VALUES (2, 'Decker', 'Sasquatch', '10/2/1980',  8);
INSERT INTO [HIKE].[Hiker] ([Id],[Name],[TrailName],[DateOfBirth],[Experience])
VALUES (3, 'Silliman', 'Silly', '10/2/1980',  5);
INSERT INTO [HIKE].[Hiker] ([Id],[Name],[TrailName],[DateOfBirth],[Experience])
VALUES (4, 'Fitzsimmons', 'FitzMule', '10/2/1980',  5);
INSERT INTO [HIKE].[Hiker] ([Id],[Name],[TrailName],[DateOfBirth],[Experience])
VALUES (5, 'Huynh', 'X', '10/2/1980',  5);
INSERT INTO [HIKE].[Hiker] ([Id],[Name],[TrailName],[DateOfBirth],[Experience])
VALUES (6, 'Dann', 'LostDog', '10/2/1980',  1);

SET IDENTITY_INSERT [HIKE].[Hiker] OFF
