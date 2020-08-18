import matplotlib.pyplot as plt

fig = plt.figure(u'Gráfica de barras') # Figure
ax = fig.add_subplot(111) # Axes

notas = ['Nota 2','Nota 3',' Nota 4','Nota 5']
datos = [24, 0, 1, 25]

xx = range(len(datos))

ax.bar(xx, datos, width=0.8, align='center')
ax.set_xticks(xx)
ax.set_xticklabels(notas)

plt.show()