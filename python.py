from datetime import datetime


def timefunc(func):
    def wrapper(*args, **kwargs):
        start_time = datetime.now()
        func(*args, **kwargs)
        end_time = datetime.now()
        running_time = end_time - start_time
        print("Ran for: ", end="")
        print(running_time.total_seconds())
    return wrapper


def fib(n):
    if n == 0:
        return 0
    if n == 1:
        return 1

    return fib(n - 1) + fib(n - 2)


def fib_memo(n, dictionary):
    if n == 0:
        dictionary[n] = 0
    if n == 1:
        dictionary[n] = 1

    if not n in dictionary.keys():
        dictionary[n] = fib_memo(n-1, dictionary) + fib_memo(n-2, dictionary)

    return dictionary[n]

@timefunc
def run_fib(n, memo):
    if memo:
        # call memo version of the function with an empty dictionary
        print(f"The {n}th value of the Fibonacci sequence is {fib_memo(n, {})}.")
    else:
        print(f"The {n}th value of the Fibonacci sequence is {fib(n)}.")

# call using the number of the fibonacci sequence that you want along with whether you want the memoization variant
#run_fib(40, False)
run_fib(40, True)