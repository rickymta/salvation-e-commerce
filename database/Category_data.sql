USE [SalvationStore]
GO

INSERT INTO [dbo].[Category]([Id], [Name], [Slug], [Image], [ParentId], [IsActived], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeleedBy], [IsDeleted]) VALUES
('4c8aba93-53a5-4924-9f81-df9cdd9780bd', N'Laptop & phụ kiện', 'laptop-va-phu-kien', '1', NULL, 1, GETDATE(), NULL, NULL, NULL, NULL, NULL, 0),
('a5750039-7ad2-42e7-9d20-d9666baf455e', N'Máy đồng bộ', 'may-dong-bo', '2', NULL, 1, GETDATE(), NULL, NULL, NULL, NULL, NULL, 0),
('fc76bd70-e229-4bfe-8d93-d619f4af7592', N'Máy chơi game', 'may-choi-game', '3', NULL, 1, GETDATE(), NULL, NULL, NULL, NULL, NULL, 0),
('bd195add-c71f-4f3f-aae3-b182a8484eb3', N'Linh kiện máy tính', 'linh-kien-may-tinh', 'https://5spc.com/wp-content/uploads/2022/03/5SPC-HOT-DEAL-OPT1-edited.jpg', NULL, 1, GETDATE(), NULL, NULL, NULL, NULL, NULL, 0),
('46165e06-31a5-4566-9ad1-fcb15a00f95e', N'CPU', 'cpu', '5', 'bd195add-c71f-4f3f-aae3-b182a8484eb3', 1, GETDATE(), NULL, NULL, NULL, NULL, NULL, 0),
('44a81e4f-074b-42bc-98ff-f3de745329d1', N'Mainboard', 'mainboard', '6', 'bd195add-c71f-4f3f-aae3-b182a8484eb3', 1, GETDATE(), NULL, NULL, NULL, NULL, NULL, 0),
('13e24b0d-832e-4aec-8382-1f5589657123', N'RAM - Bộ nhớ trong', 'ram-bo-nho-trong', '7', 'bd195add-c71f-4f3f-aae3-b182a8484eb3', 1, GETDATE(), NULL, NULL, NULL, NULL, NULL, 0),
('64c7d30a-f17f-4775-90c5-b90e8e54ebf9', N'Ổ cứng HDD', 'o-cung-hdd', '8', 'bd195add-c71f-4f3f-aae3-b182a8484eb3', 1, GETDATE(), NULL, NULL, NULL, NULL, NULL, 0),
('678992b7-8f0c-4fe6-a4ca-23cab41a512c', N'Ổ cứng SSD', 'o-cung-ssd', '9', 'bd195add-c71f-4f3f-aae3-b182a8484eb3', 1, GETDATE(), NULL, NULL, NULL, NULL, NULL, 0),
('0e3df6af-7c5d-4a98-b05b-cfae141c4ef1', N'Monitor - Màn hình', 'monitor-man-hinh', '10', 'bd195add-c71f-4f3f-aae3-b182a8484eb3', 1, GETDATE(), NULL, NULL, NULL, NULL, NULL, 0),
('0bcfbb34-b113-438c-a2f4-afe57b625ad6', N'Case - vỏ máy tính', 'case-vo-may-tinh', '11', 'bd195add-c71f-4f3f-aae3-b182a8484eb3', 1, GETDATE(), NULL, NULL, NULL, NULL, NULL, 0),
('1052bd94-3039-4e28-a1f3-4e6e093fd094', N'PSU - Nguồn', 'psu-nguon', '12', 'bd195add-c71f-4f3f-aae3-b182a8484eb3', 1, GETDATE(), NULL, NULL, NULL, NULL, NULL, 0),
('a9dbe284-bebc-499a-9869-5b17892e2fed', N'Sound Card', 'sound-card', '13', 'bd195add-c71f-4f3f-aae3-b182a8484eb3', 1, GETDATE(), NULL, NULL, NULL, NULL, NULL, 0),
('d25a58a9-5961-4d0a-a0d0-23934d85ca14', N'ODD - Ổ đĩa quang', 'odd-o-dia-quang', '14', 'bd195add-c71f-4f3f-aae3-b182a8484eb3', 1, GETDATE(), NULL, NULL, NULL, NULL, NULL, 0),
('86437c92-20a9-4886-aadf-510a50de07dd', N'Máy chủ & Máy trạm', 'may-chu-may-tram', '16', NULL, 1, GETDATE(), NULL, NULL, NULL, NULL, NULL, 0),
('8509d9bf-703b-4a7a-8630-a3c1167d544b', N'Gaming Gear & Console', 'gaming-gear-va-console', 'https://cdn.techzones.vn/Data/Sites/1/media/content/blogs/gaming-gear-la-gi/techzones-tim-hieu-xem-gaming-gear-la-gi.jpg?w=1920', NULL, 1, GETDATE(), NULL, NULL, NULL, NULL, NULL, 0),
('55c60fbb-0d4b-46cd-a7bb-08866f251150', N'Loa', 'loa', '15', '8509d9bf-703b-4a7a-8630-a3c1167d544b', 1, GETDATE(), NULL, NULL, NULL, NULL, NULL, 0),
('446b52da-406e-4d1f-b6cb-d2b47e86a564', N'Bàn phím chơi game', 'ban-phim-choi-game', '18', '8509d9bf-703b-4a7a-8630-a3c1167d544b', 1, GETDATE(), NULL, NULL, NULL, NULL, NULL, 0),
('6b7cf86d-5503-4d07-b040-7a1bacc340f8', N'Chuột chơi game', 'chuot-choi-game', '19', '8509d9bf-703b-4a7a-8630-a3c1167d544b', 1, GETDATE(), NULL, NULL, NULL, NULL, NULL, 0),
('685a6e19-9de2-43ac-94b0-c1486b561c81', N'Ghế chơi game', 'ghe-choi-game', '20', '8509d9bf-703b-4a7a-8630-a3c1167d544b', 1, GETDATE(), NULL, NULL, NULL, NULL, NULL, 0),
('7ef82e6e-6b69-42ed-9240-75937016a267', N'Bàn gaming', 'ban-gaming', '21', '8509d9bf-703b-4a7a-8630-a3c1167d544b', 1, GETDATE(), NULL, NULL, NULL, NULL, NULL, 0),
('8b8b6ff5-ff6b-4ecf-bdf8-4e9fa9878e8a', N'Tai nghe chơi game', 'tai-nghe-choi-game', '22', '8509d9bf-703b-4a7a-8630-a3c1167d544b', 1, GETDATE(), NULL, NULL, NULL, NULL, NULL, 0),
('55a988a0-54bb-452e-a3c8-3c8d5dad5fa7', N'Tay cầm game', 'tay-cam-game', '23', '8509d9bf-703b-4a7a-8630-a3c1167d544b', 1, GETDATE(), NULL, NULL, NULL, NULL, NULL, 0),
('6d3f2466-d129-48df-ba47-ac4111d8ba34', N'Bàn di chuột', 'ban-di-chuot', '24', '8509d9bf-703b-4a7a-8630-a3c1167d544b', 1, GETDATE(), NULL, NULL, NULL, NULL, NULL, 0),
('857491b6-da4b-4215-a234-255e94e2b9d3', N'Máy chơi game console', 'may-choi-game-console', '25', '8509d9bf-703b-4a7a-8630-a3c1167d544b', 1, GETDATE(), NULL, NULL, NULL, NULL, NULL, 0),
('5edc4c15-984a-4197-affc-c9cea0bcd382', N'Kính thực tế ảo', 'kinh-thuc-te-ao', '26', '8509d9bf-703b-4a7a-8630-a3c1167d544b', 1, GETDATE(), NULL, NULL, NULL, NULL, NULL, 0),
('f818e9fb-a65b-453d-8d7d-72d35640692f', N'Game bản quyền', 'game-ban-quyen', '27', '8509d9bf-703b-4a7a-8630-a3c1167d544b', 1, GETDATE(), NULL, NULL, NULL, NULL, NULL, 0),
('6782efb9-e469-4588-b7a4-4888bd2644b4', N'Giải pháp tản nhiệt', 'giai-phap-tan-nhiet', '28', NULL, 1, GETDATE(), NULL, NULL, NULL, NULL, NULL, 0);
GO