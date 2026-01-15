-- 1. INSERTAR CATEGORÍAS
INSERT INTO [Categories] ([Id], [Name])
VALUES 
('f44444e9-2ba9-473a-a40f-e38cb54f9b35', 'Informática'),
('e55555e9-2ba9-473a-a40f-e38cb54f9b35', 'Gaming'),
('c33333e9-2ba9-473a-a40f-e38cb54f9b35', 'Audio');

-- 1. INSERTAR PRODUCTOS
INSERT INTO [Products] ([Id], [CategoryId], [Name], [Description], [Price])
VALUES 
(NEWID(), 'BEE061D2-D289-4AB3-B012-4AA4E30457CB', 'iPhone 15 Pro 256GB', 'Titanio natural con chip A17 Pro y sistema de cámara avanzada.', 1219.00),
(NEWID(), 'BEE061D2-D289-4AB3-B012-4AA4E30457CB', 'Xiaomi Redmi Note 13', 'Pantalla AMOLED 120Hz, cámara de 108MP y carga rápida de 33W.', 199.99),
(NEWID(), 'BEE061D2-D289-4AB3-B012-4AA4E30457CB', 'Google Pixel 8', 'El teléfono de Google con IA avanzada y la mejor cámara de su clase.', 699.00),
(NEWID(), '6050E3C9-5B15-406F-A9A5-077E64DA2CFF', 'Xbox Series X 1TB', 'La consola más potente de Microsoft con 4K nativo y 120 FPS.', 549.00),
(NEWID(), '6050E3C9-5B15-406F-A9A5-077E64DA2CFF', 'ASUS ROG Ally Z1 Extreme', 'Consola portátil gaming con Windows 11 y pantalla Full HD.', 649.00),
(NEWID(), 'D28888E9-2BA9-473A-A40F-E38CB54F9B35', 'Televisor Hisense 50" 4K', 'Smart TV con Dolby Vision HDR y modo juego optimizado.', 349.00),
(NEWID(), 'D28888E9-2BA9-473A-A40F-E38CB54F9B35', 'Barra de Sonido Sony HT-S40R', 'Sistema de cine en casa 5.1 con altavoces traseros inalámbricos.', 329.00),
(NEWID(), 'A11111E9-2BA9-473A-A40F-E38CB54F9B35', 'Freidora de aire Cosori 5.5L', 'Tecnología de circulación de aire 360° para cocinar con menos aceite.', 119.99),
(NEWID(), 'A11111E9-2BA9-473A-A40F-E38CB54F9B35', 'Robot Aspirador Cecotec Conga', 'Aspira, barre, friega y pasa la mopa con navegación láser.', 249.00),
(NEWID(), 'A11111E9-2BA9-473A-A40F-E38CB54F9B35', 'Cafetera Nespresso Vertuo Pop', 'Sistema de cápsulas centrífugas para un café con crema perfecta.', 99.00),
(NEWID(), 'f44444e9-2ba9-473a-a40f-e38cb54f9b35', 'MacBook Pro 14 M3', 'Portátil profesional de 14 pulgadas con procesador M3 y 16GB RAM.', 1999.00),
(NEWID(), 'f44444e9-2ba9-473a-a40f-e38cb54f9b35', 'Monitor Dell UltraSharp 27', 'Resolución 4K, panel IPS y conectividad USB-C Power Delivery.', 649.50),
(NEWID(), 'e55555e9-2ba9-473a-a40f-e38cb54f9b35', 'Logitech G Pro Keyboard', 'Teclado mecánico TKL con switches Blue y RGB personalizable.', 129.99),
(NEWID(), 'e55555e9-2ba9-473a-a40f-e38cb54f9b35', 'Ratón Razer DeathAdder V3', 'Ratón ergonómico ultra ligero de 59g para eSports.', 85.00),
(NEWID(), 'e55555e9-2ba9-473a-a40f-e38cb54f9b35', 'Silla Gaming Secretlab Titan', 'Ergonomía premium con soporte lumbar magnético.', 549.00),
(NEWID(), 'c33333e9-2ba9-473a-a40f-e38cb54f9b35', 'Sony WH-1000XM5', 'Auriculares con cancelación de ruido líder, 30h de batería.', 349.00),
(NEWID(), 'c33333e9-2ba9-473a-a40f-e38cb54f9b35', 'AirPods Pro Gen 2', 'Audio adaptativo y cancelación activa de ruido mejorada.', 279.00),
(NEWID(), '6050e3c9-5b15-406f-a9a5-077e64da2cff', 'Mando DualSense Edge', 'Mando pro para PS5 con gatillos y botones traseros mapeables.', 239.99);