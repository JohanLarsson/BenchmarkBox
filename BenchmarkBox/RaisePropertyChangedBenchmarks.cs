namespace BenchmarkBox
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;
    using BenchmarkDotNet.Attributes;

    public class RaisePropertyChangedBenchmarks : INotifyPropertyChanged
    {
        private int expressionValue;
        private int callerMemberNameValue;

        public event PropertyChangedEventHandler PropertyChanged;

        public int ExpressionValue
        {
            get => this.expressionValue;
            set
            {
                if (value == this.expressionValue)
                {
                    return;
                }

                this.expressionValue = value;
                this.OnPropertyChanged(() => this.ExpressionValue);
            }
        }

        public int CallerMemberNameValue
        {
            get => this.callerMemberNameValue;
            set
            {
                if (value == this.callerMemberNameValue)
                {
                    return;
                }

                this.callerMemberNameValue = value;
                this.OnPropertyChanged();
            }
        }

        [Benchmark]
        public void SetWithExpression()
        {
            this.ExpressionValue++;
        }

        [Benchmark(Baseline = true)]
        public void SetWithCallerMemberName()
        {
            this.CallerMemberNameValue++;
        }

        protected void OnPropertyChanged<T>(Expression<Func<T>> expression)
        {
            var property = (MemberExpression)expression.Body;
            this.OnPropertyChanged(property.Member.Name);
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}