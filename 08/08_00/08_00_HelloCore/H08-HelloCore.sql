
SET IDENTITY_INSERT [dbo].[Klant] ON
INSERT INTO [dbo].[Klant] ([KlantID], [Naam], [Voornaam], [AangemaaktDatum]) VALUES (1, N'Van Der Neffe', N'Leon', N'2022-10-01 00:00:00')
INSERT INTO [dbo].[Klant] ([KlantID], [Naam], [Voornaam], [AangemaaktDatum]) VALUES (2, N'Van De Kasseinen', N'Firmin', N'2022-10-02 00:00:00')
INSERT INTO [dbo].[Klant] ([KlantID], [Naam], [Voornaam], [AangemaaktDatum]) VALUES (3, N'Kiekeboe', N'Marcel', N'2022-10-03 00:00:00')
SET IDENTITY_INSERT [dbo].[Klant] OFF

SET IDENTITY_INSERT [dbo].[Product] ON
INSERT INTO [dbo].[Product] ([ProductID], [Naam], [Prijs], [Beschrijving], [Merk]) VALUES (1, N'fiets', CAST(100.00 AS Decimal(18, 2)), N'Dit is een fiets', N'Gazelle')
INSERT INTO [dbo].[Product] ([ProductID], [Naam], [Prijs], [Beschrijving], [Merk]) VALUES (2, N'koersfiets', CAST(200.00 AS Decimal(18, 2)), N'Dit is een mooie koersfiets', N'Sparta')
INSERT INTO [dbo].[Product] ([ProductID], [Naam], [Prijs], [Beschrijving], [Merk]) VALUES (3, N'auto', CAST(2000.00 AS Decimal(18, 2)), N'Dit is een auto', N'Opel')
SET IDENTITY_INSERT [dbo].[Product] OFF

SET IDENTITY_INSERT [dbo].[Bestelling] ON
INSERT INTO [dbo].[Bestelling] ([BestellingID], [KlantID]) VALUES (1, 1)
INSERT INTO [dbo].[Bestelling] ([BestellingID], [KlantID]) VALUES (2, 2)
INSERT INTO [dbo].[Bestelling] ([BestellingID], [KlantID]) VALUES (3, 3)
INSERT INTO [dbo].[Bestelling] ([BestellingID], [KlantID]) VALUES (4, 2)
INSERT INTO [dbo].[Bestelling] ([BestellingID], [KlantID]) VALUES (5, 3)
SET IDENTITY_INSERT [dbo].[Bestelling] OFF

SET IDENTITY_INSERT [dbo].[OrderLijn] ON
INSERT INTO [dbo].[OrderLijn] ([OrderLijnID], [Aantal], [BestellingID], [ProductID]) VALUES (1, 3, 1, 1)
INSERT INTO [dbo].[OrderLijn] ([OrderLijnID], [Aantal], [BestellingID], [ProductID]) VALUES (2, 7, 1, 2)
INSERT INTO [dbo].[OrderLijn] ([OrderLijnID], [Aantal], [BestellingID], [ProductID]) VALUES (3, 4, 2, 1)
INSERT INTO [dbo].[OrderLijn] ([OrderLijnID], [Aantal], [BestellingID], [ProductID]) VALUES (4, 1, 2, 2)
INSERT INTO [dbo].[OrderLijn] ([OrderLijnID], [Aantal], [BestellingID], [ProductID]) VALUES (5, 2, 3, 1)
INSERT INTO [dbo].[OrderLijn] ([OrderLijnID], [Aantal], [BestellingID], [ProductID]) VALUES (6, 3, 4, 1)
INSERT INTO [dbo].[OrderLijn] ([OrderLijnID], [Aantal], [BestellingID], [ProductID]) VALUES (7, 1, 4, 3)
INSERT INTO [dbo].[OrderLijn] ([OrderLijnID], [Aantal], [BestellingID], [ProductID]) VALUES (8, 2, 5, 1)
INSERT INTO [dbo].[OrderLijn] ([OrderLijnID], [Aantal], [BestellingID], [ProductID]) VALUES (9, 6, 5, 2)
INSERT INTO [dbo].[OrderLijn] ([OrderLijnID], [Aantal], [BestellingID], [ProductID]) VALUES (10, 10, 5, 3)
SET IDENTITY_INSERT [dbo].[OrderLijn] OFF


