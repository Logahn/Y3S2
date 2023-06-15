import java.util.Random;

public class MatrixMultiplication {

    private static int[][] matrixA;
    private static int[][] matrixB;
    private static int[][] resultMatrix;

    private static final int MATRIX_SIZE = 100;
    private static final int THREAD_COUNT = 4;

    public static void main(String[] args) {

        matrixA = new int[MATRIX_SIZE][MATRIX_SIZE];
        matrixB = new int[MATRIX_SIZE][MATRIX_SIZE];
        resultMatrix = new int[MATRIX_SIZE][MATRIX_SIZE];

        fillMatrices();
        Thread[] threads = new Thread[THREAD_COUNT];
        for (int i = 0; i < THREAD_COUNT; i++) {
            threads[i] = new Thread(new MatrixMultiplier(i));
            threads[i].start();
        }
        for (Thread thread : threads) {
            try {
                thread.join();
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
        printResultMatrix();
    }

    private static void fillMatrices() {
        Random random = new Random();
        for (int i = 0; i < MATRIX_SIZE; i++) {
            for (int j = 0; j < MATRIX_SIZE; j++) {
                matrixA[i][j] = random.nextInt(10);
                matrixB[i][j] = random.nextInt(10);
            }
        }
    }

    private static void printResultMatrix() {
        for (int i = 0; i < MATRIX_SIZE; i++) {
            for (int j = 0; j < MATRIX_SIZE; j++) {
                System.out.print(resultMatrix[i][j] + " ");
            }
            System.out.println();
        }
    }

    private static class MatrixMultiplier implements Runnable {

        private final int id;

        public MatrixMultiplier(int id) {
            this.id = id;
        }

        @Override
        public void run() {
            for (int i = 0; i < MATRIX_SIZE; i++) {
                for (int j = id * MATRIX_SIZE / THREAD_COUNT; j < (id + 1) * MATRIX_SIZE / THREAD_COUNT; j++) {
                    int sum = 0;
                    for (int k = 0; k < MATRIX_SIZE; k++) {
                        sum += matrixA[i][k] * matrixB[k][j];
                    }
                    resultMatrix[i][j] = sum;
                }
            }
        }
    }
}