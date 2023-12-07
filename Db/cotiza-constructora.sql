-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: mariadb:3306
-- Generation Time: Dec 07, 2023 at 01:32 PM
-- Server version: 10.6.16-MariaDB-1:10.6.16+maria~ubu2004
-- PHP Version: 8.2.13

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `cotiza-constructora`
--

-- --------------------------------------------------------

--
-- Table structure for table `clientes`
--

CREATE TABLE `clientes` (
  `Idcliente` int(11) NOT NULL,
  `Identificacion` varchar(50) NOT NULL,
  `Nombres` varchar(50) NOT NULL,
  `Apellidos` varchar(50) NOT NULL,
  `Telefono` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `clientes`
--

INSERT INTO `clientes` (`Idcliente`, `Identificacion`, `Nombres`, `Apellidos`, `Telefono`) VALUES
(2, '1001967603', 'Lois Andres', 'Fuentes Chamorro', '3135405592');

-- --------------------------------------------------------

--
-- Table structure for table `contizaciondetalles`
--

CREATE TABLE `contizaciondetalles` (
  `IdContizacionDetalle` int(11) NOT NULL,
  `IdCotizacion` int(11) NOT NULL,
  `IdMaterial` int(11) NOT NULL,
  `Valor` decimal(10,0) NOT NULL,
  `Cantidad` double NOT NULL,
  `Subtotal` decimal(10,0) NOT NULL,
  `Total` decimal(10,0) NOT NULL,
  `Iva` decimal(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `cotizaciones`
--

CREATE TABLE `cotizaciones` (
  `IdCotizacion` int(11) NOT NULL,
  `Numero` varchar(20) NOT NULL,
  `Fecha` datetime NOT NULL,
  `SubTotal` decimal(10,0) NOT NULL,
  `IVA` decimal(10,0) NOT NULL,
  `Total` decimal(10,0) NOT NULL,
  `Estado` varchar(50) NOT NULL,
  `IdCliente` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `materiales`
--

CREATE TABLE `materiales` (
  `IdMaterial` int(11) NOT NULL,
  `Codigo` varchar(255) NOT NULL,
  `Descripcion` varchar(255) NOT NULL,
  `UnidadMedida` varchar(255) NOT NULL,
  `FechaActualizacion` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clientes`
--
ALTER TABLE `clientes`
  ADD PRIMARY KEY (`Idcliente`);

--
-- Indexes for table `contizaciondetalles`
--
ALTER TABLE `contizaciondetalles`
  ADD PRIMARY KEY (`IdContizacionDetalle`),
  ADD KEY `CotizacionDetalles_Cotizacion_IdCotizacion_FK` (`IdCotizacion`),
  ADD KEY `CotizacionDetalles_Materiales_IdMaterial_FK` (`IdMaterial`);

--
-- Indexes for table `cotizaciones`
--
ALTER TABLE `cotizaciones`
  ADD PRIMARY KEY (`IdCotizacion`),
  ADD KEY `IdCliente` (`IdCliente`);

--
-- Indexes for table `materiales`
--
ALTER TABLE `materiales`
  ADD PRIMARY KEY (`IdMaterial`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clientes`
--
ALTER TABLE `clientes`
  MODIFY `Idcliente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `contizaciondetalles`
--
ALTER TABLE `contizaciondetalles`
  MODIFY `IdContizacionDetalle` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `cotizaciones`
--
ALTER TABLE `cotizaciones`
  MODIFY `IdCotizacion` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `materiales`
--
ALTER TABLE `materiales`
  MODIFY `IdMaterial` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `contizaciondetalles`
--
ALTER TABLE `contizaciondetalles`
  ADD CONSTRAINT `CotizacionDetalles_Cotizacion_IdCotizacion_FK` FOREIGN KEY (`IdCotizacion`) REFERENCES `cotizaciones` (`IdCotizacion`),
  ADD CONSTRAINT `CotizacionDetalles_Materiales_IdMaterial_FK` FOREIGN KEY (`IdMaterial`) REFERENCES `materiales` (`IdMaterial`);

--
-- Constraints for table `cotizaciones`
--
ALTER TABLE `cotizaciones`
  ADD CONSTRAINT `Cotizacion-Clientes_FK_IdCliente` FOREIGN KEY (`IdCliente`) REFERENCES `clientes` (`Idcliente`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
