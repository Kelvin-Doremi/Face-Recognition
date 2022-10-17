#ifndef __MY_TCP_H
#define __MY_TCP_H
#include <opencv2/core/version.hpp>
#include <opencv2/imgproc/imgproc.hpp>
#include <opencv2/opencv.hpp>
#include <opencv2/opencv_modules.hpp>
#include <opencv2/highgui/highgui.hpp>
#include <opencv2/video/video.hpp>

/*
*@function create_accept_tcp
*@return : int
	0: error when create or bind or listen or accept
	>0: return socket client connected, and server accept return fd; 
*/
int create_accept_tcp();

/*
*@function create_net_bufs
*@return : int
	-1: error when create net buf list
	0: return OK; 
*/
int create_net_bufs();

int close_my_tcp();

int rcvd_from_tcp(int fd, unsigned char *rcvd_buffer, int length);

int send_from_tcp(int sockfd, unsigned char *data, int length);


#define NET_IMG_MAX_C       (3)
#define NET_IMG_MAX_W       (1024)
#define NET_IMG_MAX_H       (1024)
#define NET_IMG_MAX_SZ      (NET_IMG_MAX_W*NET_IMG_MAX_H*NET_IMG_MAX_C)
#define NET_IMG_MAX_BUF_NUMS    (10)

extern int net_fd;

extern unsigned char* g_net_buf[];

extern cv::Mat* g_img;

extern int g_net_current_pos;

#define MAX_TCP_BUF_SZ (11000000UL) 

#endif

