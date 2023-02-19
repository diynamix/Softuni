DELETE CreatorsBoardgames
	WHERE BoardgameId IN (Select Id FROM Boardgames WHERE PublisherId IN (SELECT Id FROM Publishers WHERE AddressId IN (SELECT Id FROM Addresses WHERE LEFT(Town, 1) = 'L')))

DELETE Boardgames
	WHERE PublisherId IN (SELECT Id FROM Publishers WHERE AddressId IN (SELECT Id FROM Addresses WHERE LEFT(Town, 1) = 'L'))

DELETE Publishers
	WHERE AddressId IN (SELECT Id FROM Addresses WHERE LEFT(Town, 1) = 'L')

DELETE Addresses
	WHERE LEFT(Town, 1) = 'L'