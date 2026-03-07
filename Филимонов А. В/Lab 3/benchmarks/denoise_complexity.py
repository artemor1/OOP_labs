#!/usr/bin/env python3
import argparse
import random
import statistics
import time
from dataclasses import dataclass
from typing import List


@dataclass
class CaseResult:
    n: int
    rank: int
    iterations: int
    rows: int
    cols: int
    hankel_mb: float
    hankel_build_ms: float
    hankel_to_array_ms: float
    svd_flops_g: float
    rank_reconstruct_flops_g: float
    total_est_flops_g: float


def hankel(x: List[float]) -> List[List[float]]:
    rows = len(x) // 2
    cols = len(x) - rows + 1
    h = [[0.0] * cols for _ in range(rows)]
    for i in range(rows):
        xi = x[i: i + cols]
        for j in range(cols):
            h[i][j] = xi[j]
    return h


def hankel_to_array(h: List[List[float]]) -> List[float]:
    rows = len(h)
    cols = len(h[0]) if rows else 0
    n = rows + cols - 1
    x = [0.0] * n
    counts = [0] * n
    for i in range(rows):
        row = h[i]
        for j in range(cols):
            idx = i + j
            x[idx] += row[j]
            counts[idx] += 1
    for k in range(n):
        x[k] /= counts[k]
    return x


def estimate_svd_flops(m: int, n: int) -> float:
    # Rough dense SVD estimate for m >= n: 4mn^2 + 8n^3/3.
    # For m < n, swap roles.
    if m < n:
        m, n = n, m
    return 4 * m * n * n + (8.0 / 3.0) * n**3


def estimate_rank_reconstruct_flops(m: int, n: int, rank: int) -> float:
    # R += sigma * u * v^T per component ~ 2mn ops
    return 2.0 * m * n * rank


def median_ms(fn, repeats: int = 3) -> float:
    samples = []
    for _ in range(repeats):
        t0 = time.perf_counter()
        fn()
        t1 = time.perf_counter()
        samples.append((t1 - t0) * 1e3)
    return statistics.median(samples)


def run_case(n: int, rank: int, iterations: int, repeats: int) -> CaseResult:
    signal = [random.random() for _ in range(n)]
    rows = n // 2
    cols = n - rows + 1

    h_time = median_ms(lambda: hankel(signal), repeats=repeats)
    h = hankel(signal)
    h2a_time = median_ms(lambda: hankel_to_array(h), repeats=repeats)

    svd_flops = estimate_svd_flops(rows, cols) * iterations
    rank_flops = estimate_rank_reconstruct_flops(rows, cols, rank) * iterations
    hankel_ops = (rows * cols + rows * cols + n) * iterations
    total = svd_flops + rank_flops + hankel_ops

    return CaseResult(
        n=n,
        rank=rank,
        iterations=iterations,
        rows=rows,
        cols=cols,
        hankel_mb=(rows * cols * 8) / (1024**2),
        hankel_build_ms=h_time,
        hankel_to_array_ms=h2a_time,
        svd_flops_g=svd_flops / 1e9,
        rank_reconstruct_flops_g=rank_flops / 1e9,
        total_est_flops_g=total / 1e9,
    )


def main() -> None:
    p = argparse.ArgumentParser()
    p.add_argument('--lengths', default='256,512,1024,2048')
    p.add_argument('--ranks', default='1,3,10,30')
    p.add_argument('--iterations', default='1,3,10')
    p.add_argument('--repeats', type=int, default=3)
    args = p.parse_args()

    lengths = [int(x) for x in args.lengths.split(',')]
    ranks = [int(x) for x in args.ranks.split(',')]
    iterations_list = [int(x) for x in args.iterations.split(',')]

    print('n,rank,iterations,rows,cols,hankel_mb,hankel_build_ms,hankel_to_array_ms,svd_flops_g,rank_reconstruct_flops_g,total_est_flops_g')
    for n in lengths:
        for rank in ranks:
            for it in iterations_list:
                rows = n // 2
                cols = n - rows + 1
                r = min(rank, rows, cols)
                case = run_case(n=n, rank=r, iterations=it, repeats=args.repeats)
                print(f"{case.n},{case.rank},{case.iterations},{case.rows},{case.cols},{case.hankel_mb:.3f},{case.hankel_build_ms:.2f},{case.hankel_to_array_ms:.2f},{case.svd_flops_g:.3f},{case.rank_reconstruct_flops_g:.3f},{case.total_est_flops_g:.3f}")


if __name__ == '__main__':
    main()
