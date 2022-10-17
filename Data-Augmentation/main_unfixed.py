# coding=utf-8
import os
import cv2
import numpy as np
import glob


def save_label(path_origin, path_save):
    if os.path.exists(path_origin + ".txt"):
        fr = open(path_origin + ".txt", "r")
        fw = open(path_save + ".txt", "w", encoding="utf-8")
        label = fr.read()
        label_list = label.split("\n")
        label_list.remove("")
        for data in label_list:
            data_list = data.split(" ")
            object_class, x_center, y_center, width, height = data_list
            object_class = int(object_class)
            x_center = float(x_center)
            y_center = float(y_center)
            width = float(width)
            height = float(height)
            fw.write("%d %f %f %f %f\n" % (object_class, x_center, y_center, width, height))
        fr.close()
        fw.close()


def fun_scale(path_img, scale):
    fr = open(path_img + ".txt", "r")
    fw = open(path_img + "_scale_" + str(scale) + ".txt", "w", encoding="utf-8")
    label = fr.read()
    fr.close()
    label_list = label.split("\n")
    label_list.remove("")
    for data in label_list:
        data_list = data.split(" ")
        object_class, x_center, y_center, width, height = data_list
        object_class = int(object_class)
        x_center = float(x_center) * scale
        y_center = float(y_center) * scale
        width = float(width) * scale
        height = float(height) * scale
        if x_center > 1 or y_center > 1 or width > 1 or height > 1:
            print("the scale is too large!!!")
            fw.close()
            os.remove(path_img + "_scale_" + str(scale) + ".txt")
            return
        fw.write("%d %f %f %f %f\n" % (object_class, x_center, y_center, width, height))
    fw.close()

    img = cv2.imread(path_img + ".jpg")
    img_shape = img.shape
    img = cv2.resize(img, None, fx=scale, fy=scale)
    canvas = np.zeros(img_shape, dtype=np.uint8)
    y_lim = int(min(scale, 1) * img_shape[0])
    x_lim = int(min(scale, 1) * img_shape[1])
    canvas[:y_lim, :x_lim, :] = img[:y_lim, :x_lim, :]
    cv2.imwrite(path_img + "_scale_" + str(scale) + ".jpg", canvas)


def fun_translate(path_img, shift):
    fr = open(path_img + ".txt", "r")
    fw = open(path_img + "_shift_" + str(shift) + ".txt", "w", encoding="utf-8")
    label = fr.read()
    fr.close()
    label_list = label.split("\n")
    label_list.remove("")
    for data in label_list:
        data_list = data.split(" ")
        object_class, x_center, y_center, width, height = data_list
        object_class = int(object_class)
        x_center = float(x_center) + shift[0]
        y_center = float(y_center) + shift[1]
        width = float(width)
        height = float(height)
        if x_center > 1 or y_center > 1 or width > 1 or height > 1:
            print("the shift is too large!!!")
            fw.close()
            os.remove(path_img + "_shift_" + str(shift) + ".txt")
            return
        fw.write("%d %f %f %f %f\n" % (object_class, x_center, y_center, width, height))
    fw.close()

    img = cv2.imread(path_img + ".jpg")
    height, width = img.shape[:2]
    x_shift = shift[0] * width
    y_shift = shift[1] * height
    matrix = np.float32([[1, 0, x_shift], [0, 1, y_shift]])
    trans_img = cv2.warpAffine(img, matrix, (width, height))
    cv2.imwrite(path_img + "_shift_" + str(shift) + ".jpg", trans_img)


def show_all():
    cnt = 0
    file_root = "./images/"
    list_file = glob.glob(file_root + "*.jpg")
    for img_path in list_file:
        cnt += 1
        print("cnt=%d,img_name=%s" % (cnt, img_path))
        path = img_path.replace(".jpg", "")
        list_scale = [0.68]
        for scale in list_scale:
            fun_scale(path, scale)

    list_file = glob.glob(file_root + "*scale_0.52*.jpg")
    for img_path in list_file:
        cnt += 1
        print("cnt=%d,img_name=%s" % (cnt, img_path))
        path = img_path.replace(".jpg", "")
        list_shift = [[0.48, 0], [0, 0.48], [0.48, 0.48]]
        for shift in list_shift:
            fun_translate(path, shift)

    list_file = glob.glob(file_root + "*scale_0.68*.jpg")
    for img_path in list_file:
        cnt += 1
        print("cnt=%d,img_name=%s" % (cnt, img_path))
        path = img_path.replace(".jpg", "")
        list_shift = [[0.32, 0], [0, 0.32], [0.32, 0.32]]
        for shift in list_shift:
            fun_translate(path, shift)

    list_file = glob.glob(file_root + "*scale_0.84*.jpg")
    for img_path in list_file:
        cnt += 1
        print("cnt=%d,img_name=%s" % (cnt, img_path))
        path = img_path.replace(".jpg", "")
        list_shift = [[0.16, 0], [0, 0.16], [0.16, 0.16]]
        for shift in list_shift:
            fun_translate(path, shift)


if __name__ == "__main__":
    show_all()
