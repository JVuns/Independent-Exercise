import tkinter as tk
main_window = tk.Tk()
greeting = tk.Label(text="Hello, Tkinter")
greeting.pack()
label = tk.Label(
    text="test",
    foreground = "red",
    background = "black")
label.pack()
main_window.mainloop()