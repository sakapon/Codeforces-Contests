# CFR 621

## D
field i に対し、field 1 からの距離を x_i、field n からの距離を y_i で表すとき、次の値を求めることになります。

```
M := max(min(x_i + y_j, x_j + y_i)) + 1
(max の変数である i, j は special field)
```

このとき、求める解は `min(x_n, M)` となります。

M の式の min において `x_i + y_j ≤ x_j + y_i` となる場合のみ考えれば十分です。  
これは 1 → i → j → n と移動することを意味します。  
`x_i - y_i ≤ x_j - y_j` より、
