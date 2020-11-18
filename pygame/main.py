import pygame
# from pygame.locals import *
pygame.init()
window = pygame.display.set_mode((1080,720))
running = True
gray = [112,112,112]
black = [0,0,0]
while running:
    for event in pygame.event.get():
        if event.type == pygame.KEYDOWN: #a = 97, s=115, w=100 d=119
            print(event)
            window.fill(gray)
            pygame.display.update()
    if event.type == pygame.QUIT:
        running = False
pygame.quit()