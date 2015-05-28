SET IDENTITY_INSERT [dbo].[Barangs] ON
	INSERT INTO [dbo].[Barangs] ([Id], [Nama], [Harga]) VALUES (1, N'barang1', 100)
	INSERT INTO [dbo].[Barangs] ([Id], [Nama], [Harga]) VALUES (2, N'barang2', 200)
	INSERT INTO [dbo].[Barangs] ([Id], [Nama], [Harga]) VALUES (3, N'barang3', 300)
	INSERT INTO [dbo].[Barangs] ([Id], [Nama], [Harga]) VALUES (4, N'barang4', 400)
	INSERT INTO [dbo].[Barangs] ([Id], [Nama], [Harga]) VALUES (5, N'barang5', 500)
SET IDENTITY_INSERT [dbo].[Barangs] OFF

SET IDENTITY_INSERT [dbo].[KategoriPembelis] ON
	INSERT INTO [dbo].[KategoriPembelis] ([Id], [Nama]) VALUES (1, N'Member')
	INSERT INTO [dbo].[KategoriPembelis] ([Id], [Nama]) VALUES (2, N'Bukan Member')
SET IDENTITY_INSERT [dbo].[KategoriPembelis] OFF


SET IDENTITY_INSERT [dbo].[Pembelis] ON
	INSERT INTO [dbo].[Pembelis] ([Id], [Nama], [JenisKelamin], [TTL], [KategoriPembeli_Id]) 
	VALUES (1, N'Pembeli1', N'L', N'28-05-1980', 1)
	INSERT INTO [dbo].[Pembelis] ([Id], [Nama], [JenisKelamin], [TTL], [KategoriPembeli_Id]) 
	VALUES (2, N'Pembeli2', N'P', N'01-02-1985', 2)
	INSERT INTO [dbo].[Pembelis] ([Id], [Nama], [JenisKelamin], [TTL], [KategoriPembeli_Id]) 
	VALUES (3, N'Pembeli3', N'P', N'12-08-1998', 1)
SET IDENTITY_INSERT [dbo].[Pembelis] OFF
