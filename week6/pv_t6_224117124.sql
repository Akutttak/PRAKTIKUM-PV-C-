/*
SQLyog Community v13.3.1 (64 bit)
MySQL - 8.0.30 : Database - pv_t6_224117124
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`pv_t6_224117124` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `pv_t6_224117124`;

/*Table structure for table `axe_inventory` */

DROP TABLE IF EXISTS `axe_inventory`;

CREATE TABLE `axe_inventory` (
  `id` int NOT NULL AUTO_INCREMENT,
  `user_id` int DEFAULT NULL,
  `nama_axe` varchar(255) DEFAULT NULL,
  `harga` int DEFAULT NULL,
  `tipe` varchar(255) DEFAULT NULL,
  `aktif` tinyint DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `user_id` (`user_id`),
  CONSTRAINT `axe_inventory_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `axe_inventory` */

/*Table structure for table `log_inventory` */

DROP TABLE IF EXISTS `log_inventory`;

CREATE TABLE `log_inventory` (
  `id` int NOT NULL AUTO_INCREMENT,
  `user_id` int DEFAULT NULL,
  `nama_kayu` varchar(255) DEFAULT NULL,
  `jumlah` int DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `user_id` (`user_id`),
  CONSTRAINT `log_inventory_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `log_inventory` */

insert  into `log_inventory`(`id`,`user_id`,`nama_kayu`,`jumlah`) values 
(1,1,'mahogany',8),
(2,1,'oak',4);

/*Table structure for table `sales` */

DROP TABLE IF EXISTS `sales`;

CREATE TABLE `sales` (
  `id` int NOT NULL AUTO_INCREMENT,
  `user_id` int NOT NULL,
  `wood_name` varchar(255) DEFAULT NULL,
  `quantity` int DEFAULT NULL,
  `price_per_item` int DEFAULT NULL,
  `total_price` int DEFAULT NULL,
  `sale_date` datetime DEFAULT CURRENT_TIMESTAMP,
  `day` int NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `user_id` (`user_id`),
  CONSTRAINT `sales_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `sales` */

insert  into `sales`(`id`,`user_id`,`wood_name`,`quantity`,`price_per_item`,`total_price`,`sale_date`,`day`) values 
(38,1,'Mahogany',1,240,240,'2025-11-06 12:40:35',2),
(39,1,'Mahogany',1,240,240,'2025-11-06 12:59:59',3);

/*Table structure for table `users` */

DROP TABLE IF EXISTS `users`;

CREATE TABLE `users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nama` varchar(255) DEFAULT NULL,
  `uang` int DEFAULT '0',
  `axe_aktif` varchar(255) DEFAULT NULL,
  `game_day` int NOT NULL DEFAULT '1',
  `game_hour` int NOT NULL DEFAULT '6',
  `game_menit` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `users` */

insert  into `users`(`id`,`nama`,`uang`,`axe_aktif`,`game_day`,`game_hour`,`game_menit`) values 
(1,'Player',97990,NULL,3,7,30);

/*Table structure for table `warung_inventory` */

DROP TABLE IF EXISTS `warung_inventory`;

CREATE TABLE `warung_inventory` (
  `id` int NOT NULL AUTO_INCREMENT,
  `warung_id` int NOT NULL,
  `shelf_id` int NOT NULL,
  `wood_name` varchar(50) DEFAULT NULL,
  `price` int DEFAULT NULL,
  `stock` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `warung_id` (`warung_id`),
  CONSTRAINT `warung_inventory_ibfk_1` FOREIGN KEY (`warung_id`) REFERENCES `warung_user` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `warung_inventory` */

insert  into `warung_inventory`(`id`,`warung_id`,`shelf_id`,`wood_name`,`price`,`stock`) values 
(13,1,1,'Oak',100,0),
(14,1,1,'Mahogany',240,0),
(15,1,1,'Mahogany',240,0),
(16,1,1,'Mahogany',10,1),
(17,1,1,'Mahogany',1,1);

/*Table structure for table `warung_user` */

DROP TABLE IF EXISTS `warung_user`;

CREATE TABLE `warung_user` (
  `id` int NOT NULL AUTO_INCREMENT,
  `user_id` int NOT NULL,
  `nama_warung` varchar(255) DEFAULT 'Warung Kayu',
  `level_warung` int NOT NULL DEFAULT '1',
  `sudah_beli` tinyint DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `user_id` (`user_id`),
  CONSTRAINT `warung_user_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `warung_user` */

insert  into `warung_user`(`id`,`user_id`,`nama_warung`,`level_warung`,`sudah_beli`) values 
(1,1,'Warung Kayu',1,1);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
