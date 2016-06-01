/*
Navicat MySQL Data Transfer

Source Server         : 10.7.84.91
Source Server Version : 50547
Source Host           : 10.7.84.91:3306
Source Database       : csm

Target Server Type    : MYSQL
Target Server Version : 50547
File Encoding         : 65001

Date: 2016-06-01 17:12:43
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for customer
-- ----------------------------
DROP TABLE IF EXISTS `customer`;
CREATE TABLE `customer` (
  `GUID` varchar(50) NOT NULL,
  `UID` varchar(50) DEFAULT NULL,
  `OpenID` varchar(50) DEFAULT NULL,
  `Channel` varchar(255) DEFAULT NULL,
  `NickName` varchar(255) DEFAULT NULL,
  `headimgurl` varchar(255) DEFAULT NULL,
  `sex` int(1) DEFAULT NULL,
  `City` varchar(50) DEFAULT NULL,
  `province` varchar(20) DEFAULT NULL,
  `country` varchar(20) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `phone` varchar(11) DEFAULT NULL,
  `FollowTime` datetime DEFAULT NULL,
  `CreateUser` varchar(255) DEFAULT NULL,
  `CreateTime` datetime DEFAULT NULL,
  `UpdateUser` varchar(255) DEFAULT NULL,
  `UpdateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`GUID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='1男2女';

-- ----------------------------
-- Records of customer
-- ----------------------------

-- ----------------------------
-- Table structure for message
-- ----------------------------
DROP TABLE IF EXISTS `message`;
CREATE TABLE `message` (
  `MessageID` varchar(50) DEFAULT NULL,
  `From` varchar(50) DEFAULT NULL,
  `To` varchar(50) DEFAULT NULL,
  `Content` varchar(200) DEFAULT NULL,
  `Title` varchar(200) DEFAULT NULL,
  `Link` varchar(200) DEFAULT NULL,
  `CreateTime` datetime DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of message
-- ----------------------------

-- ----------------------------
-- Table structure for servicer
-- ----------------------------
DROP TABLE IF EXISTS `servicer`;
CREATE TABLE `servicer` (
  `GUID` varchar(255) DEFAULT NULL,
  `ServicerID` varchar(255) DEFAULT NULL,
  `OpenID` varchar(255) DEFAULT NULL,
  `UserID` varchar(255) DEFAULT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `Sex` varchar(1) DEFAULT NULL,
  `Phone` varchar(11) DEFAULT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `CreateUser` varchar(255) DEFAULT NULL,
  `CreateTime` datetime DEFAULT NULL,
  `UpdateUser` varchar(255) DEFAULT NULL,
  `UpdateTime` datetime DEFAULT NULL,
  `Status` varchar(1) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of servicer
-- ----------------------------

-- ----------------------------
-- Table structure for supporter
-- ----------------------------
DROP TABLE IF EXISTS `supporter`;
CREATE TABLE `supporter` (
  `GUID` varchar(50) DEFAULT NULL,
  `UserID` varchar(255) DEFAULT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `Department` varchar(20) DEFAULT NULL,
  `Position` varchar(255) DEFAULT NULL,
  `Mobile` varchar(11) DEFAULT NULL,
  `Gender` varchar(255) DEFAULT NULL,
  `WeixinID` varchar(255) DEFAULT NULL,
  `Avatar_Mediaid` varchar(255) DEFAULT NULL,
  `UpdateUser` varchar(255) DEFAULT NULL,
  `UpdateTime` datetime DEFAULT NULL,
  `CreateTime` datetime DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of supporter
-- ----------------------------

-- ----------------------------
-- Table structure for taskassign
-- ----------------------------
DROP TABLE IF EXISTS `taskassign`;
CREATE TABLE `taskassign` (
  `GUID` varchar(50) DEFAULT NULL,
  `TaskID` varchar(50) DEFAULT NULL,
  `AssignID` varchar(50) DEFAULT NULL,
  `TaskStatus` varchar(1) DEFAULT NULL,
  `BookTime` datetime DEFAULT NULL,
  `FeedBack` varchar(2000) DEFAULT NULL,
  `AssignUser` varchar(50) DEFAULT NULL,
  `CreateUser` varchar(50) DEFAULT NULL,
  `UpdateTime` datetime DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='TaskStatus 1接受 2 拒绝 3预约上门时间 4工单完成关闭';

-- ----------------------------
-- Records of taskassign
-- ----------------------------

-- ----------------------------
-- Table structure for taskinfor
-- ----------------------------
DROP TABLE IF EXISTS `taskinfor`;
CREATE TABLE `taskinfor` (
  `GUID` varchar(50) DEFAULT NULL,
  `TaskID` varchar(50) DEFAULT NULL,
  `CustomerID` varchar(50) DEFAULT NULL,
  `ProductID` varchar(50) DEFAULT NULL,
  `Channel` varchar(2) DEFAULT NULL,
  `Content` varchar(2000) DEFAULT NULL,
  `Level` varchar(1) DEFAULT NULL,
  `Adress` varchar(2000) DEFAULT NULL,
  `ContactName` varchar(200) DEFAULT NULL,
  `Phone` varchar(11) DEFAULT NULL,
  `Email` varchar(200) DEFAULT NULL,
  `CreateTime` datetime DEFAULT NULL,
  `Remark` varchar(2) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of taskinfor
-- ----------------------------

-- ----------------------------
-- Table structure for taskresources
-- ----------------------------
DROP TABLE IF EXISTS `taskresources`;
CREATE TABLE `taskresources` (
  `GUID` varchar(50) DEFAULT NULL,
  `ResID` varchar(50) DEFAULT NULL,
  `TaskID` varchar(50) DEFAULT NULL,
  `ResType` varchar(10) DEFAULT NULL,
  `ResPath` varchar(1000) DEFAULT NULL,
  `CreateUser` varchar(50) DEFAULT NULL,
  `CreateTime` datetime DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='img表示图片';

-- ----------------------------
-- Records of taskresources
-- ----------------------------
