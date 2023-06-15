from typing import List


def count_beds(N: int, M: int, garden: List[List[int]]) -> int:
    bed_count = 0
    for i in range(N):
        for j in range(M):
            if garden[i][j] == 0:
                bed_count += 1
                dfs(i, j, garden, bed_count)
    return bed_count


def dfs(row: int, col: int, garden: List[List[int]], bed: int) -> None:
    if row < 0 or row >= len(garden) or col < 0 or col >= len(garden[0]) or garden[row][col] != 0:
        return
    garden[row][col] = bed
    dfs(row+1, col, garden, bed)
    dfs(row-1, col, garden, bed)
    dfs(row, col+1, garden, bed)
    dfs(row, col-1, garden, bed)


N = 7
M = 8
garden = [[0, 0, 0, 0, 0, 0, 0, 0],
          [0, 1, 1, 0, 1, 1, 1, 1],
          [0, 1, 0, 0, 1, 0, 0, 1],
          [0, 1, 1, 0, 1, 0, 0, 1],
          [0, 0, 0, 0, 0, 0, 0, 0],
          [0, 0, 0, 0, 0, 0, 0, 0],
          [0, 1, 1, 0, 0, 0, 1, 1]
          ]
print(f"Kоличество грядок на садовом участке = {(count_beds(N, M, garden))}")
