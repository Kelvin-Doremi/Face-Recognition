# coding=utf-8
import os
import cv2
import numpy as np
from PIL import Image
from PIL import ImageEnhance

"""
1、对比度：白色画面(最亮时)下的亮度除以黑色画面(最暗时)下的亮度；
2、色彩饱和度：：彩度除以明度，指色彩的鲜艳程度，也称色彩的纯度；
3、色调：向负方向调节会显现红色，正方向调节则增加黄色。适合对肤色对象进行微调；
4、锐度：是反映图像平面清晰度和图像边缘锐利程度的一个指标。
"""


def compute(img):
    b_mean = np.mean(img[:, :, 0])
    g_mean = np.mean(img[:, :, 1])
    r_mean = np.mean(img[:, :, 2])
    return 0.299 * r_mean + 0.587 * g_mean + 0.114 * b_mean


def fun_bright(image, coefficient, path_save):
    # 变亮 1.5
    # 变暗 0.8
    # 亮度增强,增强因子为0.0将产生黑色图像； 为1.0将保持原始图像。
    enh_bri = ImageEnhance.Brightness(image)
    image_brightened1 = enh_bri.enhance(coefficient)
    image_brightened1.save(path_save + ".jpg")


def fun_color(image, coefficient, path_save):
    # 色度,增强因子为1.0是原始图像
    # 色度增强 1.5
    # 色度减弱 0.8
    enh_col = ImageEnhance.Color(image)
    image_colored1 = enh_col.enhance(coefficient)
    image_colored1.save(path_save + ".jpg")


def fun_contrast(image, coefficient, path_save):
    # 对比度，增强因子为1.0是原始图片
    # 对比度增强 1.5
    # 对比度减弱 0.8
    enh_con = ImageEnhance.Contrast(image)
    image_contrasted1 = enh_con.enhance(coefficient)
    image_contrasted1.save(path_save + ".jpg")


def fun_sharpness(image, coefficient, path_save):
    # 锐度，增强因子为1.0是原始图片
    # 锐度增强 3
    # 锐度减弱 0.8
    enh_sha = ImageEnhance.Sharpness(image)
    image_sharped1 = enh_sha.enhance(coefficient)
    image_sharped1.save(path_save + ".jpg")


def save_label(path_origin, path_save):
    if os.path.exists(path_origin + ".txt"):
        fr = open(path_origin + ".txt", "r")
        fw = open(path_save + ".txt", "w", encoding="utf-8")
        fw.write(fr.read())
        fr.close()
        fw.close()


def show_all():
    file_root = "./images/"
    save_root = "./img_aug/"
    list_file = os.listdir(file_root)
    cnt = 0
    for img_name in list_file:
        if img_name.find("txt") >= 0:
            continue
        cnt += 1
        print("cnt=%d,img_name=%s" % (cnt, img_name))
        name = img_name.replace(".jpg", "")
        path = file_root + name
        image = Image.open(path + ".jpg")

        """
        aug1

        img = cv2.imread(path + ".jpg")
        mean_1 = compute(img)

        if mean_1 < 40:
            cof = 3.5
        elif mean_1 < 60:
            cof = 3
        elif mean_1 < 80:
            cof = 2
        elif mean_1 < 90:
            cof = 1.5
        elif mean_1 < 110:
            cof = 1.1
        elif mean_1 > 130:
            cof = 0.5
        else:
            cof = 0.75

        if cof > 1:
            cof_contrast = 1.5
        else:
            cof_contrast = 0.8

        path_save_bright = save_root + name + "_bri_" + str(cof)
        fun_bright(image, cof, path_save_bright)
        save_label(path, path_save_bright)

        path_save_color = save_root + name + "_color_" + str(1.5)
        fun_color(image, 1.5, path_save_color)
        save_label(path, path_save_color)

        path_save_contra = save_root + name + "_contra_" + str(cof_contrast)
        fun_contrast(image, cof_contrast, path_save_contra)
        save_label(path, path_save_contra)

        path_save_sharp = save_root + name + "_sharp_" + str(2)
        fun_sharpness(image, 2, path_save_sharp)
        save_label(path, path_save_sharp)
        """

        """
        aug2
        """
        list_coe = [0.5, 1.5]
        for val in list_coe:
            path_save_bright = save_root + name + "_bri_" + str(val)
            fun_bright(image, val, path_save_bright)
            save_label(path, path_save_bright)

            path_save_color = save_root + name + "_color_" + str(val)
            #fun_color(image, val, path_save_color)
            #save_label(path, path_save_color)

            path_save_contra = save_root + name + "_contra_" + str(val)
            fun_contrast(image, val, path_save_contra)
            save_label(path, path_save_contra)

            path_save_sharp = save_root + name + "_sharp_" + str(val)
            #fun_sharpness(image, val, path_save_sharp)
            #save_label(path, path_save_sharp)


if __name__ == "__main__":
    show_all()
