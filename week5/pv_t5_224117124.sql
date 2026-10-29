/*
SQLyog Community v13.3.1 (64 bit)
MySQL - 8.0.30 : Database - pv_t5_224117124
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`pv_t5_224117124` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `pv_t5_224117124`;

/*Table structure for table `movie` */

DROP TABLE IF EXISTS `movie`;

CREATE TABLE `movie` (
  `movieId` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `title` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `genre` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `duration` int NOT NULL,
  `studioId` int DEFAULT NULL,
  `isFinished` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`movieId`),
  KEY `studioId` (`studioId`),
  CONSTRAINT `movie_ibfk_1` FOREIGN KEY (`studioId`) REFERENCES `studio` (`studioId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `movie` */

insert  into `movie`(`movieId`,`title`,`genre`,`duration`,`studioId`,`isFinished`) values 
('MOV001','Avengers: Endgame','Action, Sci-Fi',181,1,0),
('MOV002','Frozen II','Animation, Comedy',135,2,0),
('MOV003','Conjuring 3','Horror',120,3,0),
('MOV004','Alice in Borderland','Action',500,3,NULL);

/*Table structure for table `studio` */

DROP TABLE IF EXISTS `studio`;

CREATE TABLE `studio` (
  `studioId` int NOT NULL AUTO_INCREMENT,
  `studioName` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `basePrice` decimal(10,0) NOT NULL,
  `seat1` tinyint(1) DEFAULT '0',
  `seat2` tinyint(1) DEFAULT '0',
  `seat3` tinyint(1) DEFAULT '0',
  `seat4` tinyint(1) DEFAULT '0',
  `seat5` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`studioId`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `studio` */

insert  into `studio`(`studioId`,`studioName`,`basePrice`,`seat1`,`seat2`,`seat3`,`seat4`,`seat5`) values 
(1,'Studio 1',35000,1,0,0,0,0),
(2,'Studio 2',40000,0,0,0,0,0),
(3,'Studio 3',45000,0,0,0,0,0),
(4,'sdgsdfs',30000,0,0,0,0,0);

/*Table structure for table `user` */

DROP TABLE IF EXISTS `user`;

CREATE TABLE `user` (
  `userId` int NOT NULL AUTO_INCREMENT,
  `nama` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `username` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `password` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `role` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `balance` decimal(10,0) NOT NULL,
  PRIMARY KEY (`userId`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `user` */

insert  into `user`(`userId`,`nama`,`username`,`password`,`role`,`balance`) values 
(1,'admin','admin','admin','admin',1000000),
(2,'joni','joni','123','user',925000),
(3,'ferlinda','ferlinda','123','user',15000),
(4,'klepong','kle123','kle123','user',30000);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
